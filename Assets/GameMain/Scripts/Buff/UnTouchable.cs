using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject{
    public class UnTouchable : BaseCharactorBuff
    {
        public UnTouchable(int inIdx, float inTime, BaseActor effectActor) : base(inIdx, inTime, effectActor)
        {
        }

        public override void Start()
        {
            base.Start();
            m_EffectActor.AddEgnoreLayer(EgnoreEffect.Hurt, EgnoreEffect.DBuff);
        }
        public override void End()
        {
            base.End();
            m_EffectActor.RemoveEgnoreLayer(EgnoreEffect.Hurt, EgnoreEffect.DBuff);
        }
    }
}
