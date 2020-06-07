using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace ETModel
{
    /***
     * 复用性太差，
     */
    public class Skill : Entity
    {
        private SkillData skillData;
        private Skill next;
        private SkillHolder skillHolder;
        public SkillData SkillData { get => skillData; set => skillData = value; }
        public Skill Next { get => next; set => next = value; }
        public SkillHolder SkillHolder { get => skillHolder; set => skillHolder = value; }

        public Skill(SkillData rootSkillData)
        {
            this.skillData = rootSkillData;
            Skill nextSkill = null;
            SkillData SkillData = rootSkillData.next;
            if (SkillData != null)
            {
                Next = new Skill(SkillData);
                nextSkill = Next;
                while (SkillData.next != null)
                {
                    nextSkill.next = new Skill(SkillData.next);
                    SkillData = SkillData.next;
                    nextSkill = nextSkill.next;
                }
            }

        }


        public virtual async ETTask CreateSkillUnit()
        {
            skillHolder.SkillUnit = ComponentFactory.Create<Unit>();
            if (SkillData.shape != null)
            {
                skillHolder.SkillUnit.AddComponent<ColliderComponent, Unit, ColliderShape>(skillHolder.BeLongUnit, SkillData.shape);
                skillHolder.SkillUnit.AddComponent<SkillDataComponent, long>(SkillData.id);
                Game.EventSystem.Run<Entity>(SkillData.shape.collisionEvent, skillHolder.SkillUnit);
            }
            await ETTask.CompletedTask;
        }

      
    }

    public class DurationSkill : Skill
    {
        public int duration;
        public DurationSkill(SkillData rootSkillData) : base(rootSkillData)
        {
        }
    }

    public class DynamicsSkill : Skill
    {
        public Vector3 StartPos;
        public Vector3 EndPos;
        public DynamicsSkill(SkillData rootSkillData) : base(rootSkillData)
        {
        }

        public override async ETTask CreateSkillUnit()
        {
            await base.CreateSkillUnit();
            switch (SkillData.skillInputType)
            {
                case SkillInputType.Point:
                    StartPos = SkillHolder.BeLongUnit.Position;
                    EndPos = SkillHolder.TagartPoints[0];
                    break;
                case SkillInputType.TwoPoint:
                    StartPos = SkillHolder.TagartPoints[0];
                    EndPos = SkillHolder.TagartPoints[1];
                    break;
                case SkillInputType.target:
                    StartPos = SkillHolder.BeLongUnit.Position;
                    EndPos = SkillHolder.TagartUnit.Position;
                    break;
            }
            await Move(SkillHolder.CancellationTokenSource.Token);
        }

        public virtual async ETTask Move(CancellationToken cancellationToken)
        {
            SkillHolder.SkillUnit.Position = StartPos;
            MoveComponent moveComponent = SkillHolder.SkillUnit.GetComponent<MoveComponent>();
            if (moveComponent == null)
            {
                moveComponent = SkillHolder.SkillUnit.AddComponent<MoveComponent>();
            }
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Vector3 tagartPos = (EndPos - StartPos).normalized * SkillData.distance + StartPos;
            tagartPos.y = 0;
            await moveComponent.MoveToAsync(tagartPos, SkillData.speed, cancellationTokenSource.Token);
        }
    }
    public class MoveSelfSkill : DynamicsSkill
    {
     
        public MoveSelfSkill(SkillData rootSkillData) : base(rootSkillData)
        {

        }
        public override async ETTask Move(CancellationToken cancellationToken)
        {
            EndPos.y = 0;
            await SkillHolder.BeLongUnit.GetComponent<MoveComponent>().MoveToAsync(EndPos, SkillData.speed, cancellationToken);
        }
    }
    public class MoveOtherSkill : DynamicsSkill
    {

        public MoveOtherSkill(SkillData rootSkillData) : base(rootSkillData)
        {

        }
        public override async ETTask Move(CancellationToken cancellationToken)
        {
            Vector3 tagartPos = (EndPos - StartPos).normalized * SkillData.distance + SkillHolder.TagartUnit.Position;
            tagartPos.y = 0;
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            await SkillHolder.TagartUnit.GetComponent<MoveComponent>().MoveToAsync(tagartPos, SkillData.speed, cancellationTokenSource.Token);
        }
    }

    public class SkillHolder
    {
        private Unit beLongUnit;
        private Skill rootSkill;
        private Skill currentSkill;
        private CancellationTokenSource cancellationTokenSource;
        private List<Vector3> tagartPoints = new List<Vector3>();
        private Unit tagartUnit;
        private int countDown = 0;
        private Unit skillUnit;
        private SkillState skillState;
        public Unit BeLongUnit { get => beLongUnit; set => beLongUnit = value; }
        public Skill RootSkill { get => rootSkill; set => rootSkill = value; }
        public Skill CurrentSkill { get => currentSkill; set => currentSkill = value; }
        public CancellationTokenSource CancellationTokenSource { get => cancellationTokenSource; set => cancellationTokenSource = value; }
        public List<Vector3> TagartPoints { get => tagartPoints; set => tagartPoints = value; }
        public Unit TagartUnit { get => tagartUnit; set => tagartUnit = value; }
        public int CountDown { get => countDown; set => countDown = value; }
        public Unit SkillUnit { get => skillUnit; set => skillUnit = value; }
        public SkillState SkillState
        {
            get => skillState;
            set
            {
                skillState = value;
                OnStateChanged();
            }
        }
        public void BreakSkill()
        {
            CancellationTokenSource?.Cancel();
            SkillState = SkillState.Cding;
        }
        public SkillHolder(Skill skill, Unit beLongToUnit)
        {
            RootSkill = skill;
            CurrentSkill = RootSkill;
            CurrentSkill.SkillHolder = this;
            BeLongUnit = beLongToUnit;
        }
        
        public void OnStateChanged()
        {
            switch (SkillState)
            {
                case SkillState.CanFire:
                    Prepare();
                    break;
                case SkillState.Fireing:
                    Fireing().Coroutine();
                    break;
                case SkillState.Cding:
                    SkillCd().Coroutine();
                    break;
                case SkillState.Next:
                    MoveNext().Coroutine();
                    break;
            }
            Game.EventSystem.Run<SkillHolder>(SkillcmdEvent.Send,this);
        }
        public async ETTask WaitInput() 
        {
            var timerComponent = Game.Scene.GetComponent<TimerComponent>();
            await timerComponent.WaitAsync(currentSkill.SkillData.waitInputTime, CancellationTokenSource.Token);
            await SkillCd();  
        }
        public async ETTask MoveNext()
        {
            if (CurrentSkill.Next != null)
            {
                CurrentSkill = CurrentSkill.Next;
                CurrentSkill.SkillHolder = this;
                CountDown = 0;
                CancellationTokenSource?.Cancel();
                CancellationTokenSource = new CancellationTokenSource();
                if (SkillUnit != null)
                {
                    Game.Scene.GetComponent<ColliderComponentManagerComponent>().RemoveColliderEntity(SkillUnit.Id);
                    SkillUnit.Dispose();
                }
                await WaitInput();
            }
            
        }
        public void Prepare()
        {
            CountDown = 0;
            CancellationTokenSource?.Cancel();
            CancellationTokenSource = new CancellationTokenSource();
            if (SkillUnit != null)
            {
                Game.Scene.GetComponent<ColliderComponentManagerComponent>().RemoveColliderEntity(SkillUnit.Id);
                SkillUnit.Dispose();
            }
        }
        public async ETTask Fireing()
        {
            CancellationTokenSource?.Cancel();
            CancellationTokenSource = new CancellationTokenSource();
            await Delay();
            await CurrentSkill.CreateSkillUnit();
            SkillState = SkillState.Cding;
        }
        public async ETTask Delay()
        {
            var timerComponent = Game.Scene.GetComponent<TimerComponent>();
            await timerComponent.WaitAsync(currentSkill.SkillData.delay, CancellationTokenSource.Token);
        }
        public void Clear()
        {
            if (TagartPoints.Count != 0)
            {
                TagartPoints.Clear();
            }
            TagartUnit = null;
        }
        public async ETTask SkillCd()
        {

            CountDown = currentSkill.SkillData.cd;
            if (SkillUnit != null)
            {
                Game.Scene.GetComponent<ColliderComponentManagerComponent>().RemoveColliderEntity(SkillUnit.Id);
                SkillUnit.Dispose();
            }
            while (CountDown > 0)
            {
                await Game.Scene.GetComponent<TimerComponent>().WaitAsync(1000, CancellationTokenSource.Token);
                CountDown -= 1;
            }
            CountDown = 0;
            CurrentSkill = RootSkill;
            Clear();
            SkillState = SkillState.CanFire;
        }
       
    }
}
