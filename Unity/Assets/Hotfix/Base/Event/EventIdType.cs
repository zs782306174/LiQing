﻿namespace ETHotfix
{
    public static class EventIdType
    {
        /// <summary>
        /// 登录完毕
        /// </summary>
        public const string LoginFinish = "LoginFinish";

        /// <summary>
        /// 显示战斗UI
        /// </summary>
        public const string Show5v5MapUI = "Show5v5MapUI";

        /// <summary>
        /// 关闭战斗UI
        /// </summary>
        public const string Close5v5MapUI = "Close5v5MapUI";

        /// <summary>
        /// 显示掉线对话框UI
        /// </summary>
        public const string ShowDialogUI = "ShowDialogUI";

        /// <summary>
        /// 关闭对话框UI
        /// </summary>
        public const string CloseDialogUI = "CloseDialogUI";

        /// <summary>
        /// 进入地图完毕
        /// </summary>
        public const string EnterMapFinish = "EnterMapFinish";

        /// <summary>
        /// 大厅界面的所有数据加载完毕
        /// </summary>
        public const string LobbyUIAllDataLoadComplete = "LobbyUIAllDataLoadComplete";

        /// <summary>
        /// 显示登录UI
        /// </summary>
        public const string ShowLoginUI = "ShowLoginUI";
        public const string CloseLoginUI = "CloseLoginUI";
        /// <summary>
        /// 显示加载中的UI
        /// </summary>
        public const string ShowLoadingProcess = "ShowLoadingPorcess";

        /// <summary>
        /// 点击小地图
        /// </summary>
        public const string ClickSmallMap = "ClickSmallMap";

        #region 血条相关事件

        /// <summary>
        /// 创建人物头部UI
        /// </summary>
        public const string CreateHeadBar = "CreateHeadBar";

        /// <summary>
        /// 最大生命值改变事件，意图修改血条UI密度
        /// </summary>
        public const string ChangeHPMax = "ChangeHPMax";
        
        /// <summary>
        /// 更改生命值，值为修改的量，正为加血，负为减血
        /// </summary>
        public const string ChangeHPValue = "ChangeHPValue";
        
        /// <summary>
        /// 最大蓝量改变事件
        /// </summary>
        public const string ChangeMPMax = "ChangeMPMax";
        
        /// <summary>
        /// 更改蓝量，值为修改的量，正为加蓝，负为减蓝
        /// </summary>
        public const string ChangeMPValue = "ChangeMPValue";

        #endregion
        
        /// <summary>
        /// 设置自身的英雄Unit
        /// </summary>
        public const string SetSelfHero = "SetSelfHero";
    }
}