using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{
    public class SkillFsm : Fsm
    {
        SkillList m_SkillList;
        public BaseSkillState curSkillState
        {

            get
            {
                if (m_CurState == null)
                {
                    SkillStruct newSkill = new SkillStruct();
                    SetState(new BaseSkillState(m_SkillList, newSkill));
                }
                return m_CurState as BaseSkillState;
            }
        }

        public SkillFsm(SkillList skillList)
        {
            m_SkillList = skillList;
        }
    }
}
