



using System;
using ETMode;
using ETModel;
using NodeEditorFramework;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plugins.NodeEditor
{
    public class PrevB2SType: ValueConnectionType //: IConnectionTypeDeclaration
    {
        public override string Identifier => "PrevB2SDatas";

        public override Type Type => typeof (B2S_CollisionInstance);

        public override Color Color => Color.green;

    }

    public class NextB2SType: ValueConnectionType // : IConnectionTypeDeclaration
    {
        public override string Identifier => "NextB2SDatas";

        public override Type Type => typeof (B2S_CollisionInstance);

        public override Color Color => Color.cyan;
    }
}