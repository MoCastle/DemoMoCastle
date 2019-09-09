using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{
    public class Roll : BaseSkillState
    {
        bool m_AddedBuff;
        float m_RealeaseTimeStamp = 0.2f;
        public Roll(SkillList skillList, SkillStruct skillStruct, BaseActor targetActor = null) : base(skillList, skillStruct, targetActor)
        {
            m_AddedBuff = false;
            m_RealeaseTimeStamp = Time.time + 0.2f;
        }

        protected override string GenMessage()
        {
            return m_SelfActor.gameObject.name + "开始翻滚";
        }

        protected override void EffectSkill()
        {
            if (m_BaseTarget == null)
                return;
        }

        public override void Update()
        {
            base.Update();
            if(!m_AddedBuff && m_RealeaseTimeStamp < Time.time )
            {
                m_AddedBuff = true;
                m_SelfActor.AddBuff(new UnTouchable(0, 0.9f,m_SelfActor));
            }
        }

    }
}
