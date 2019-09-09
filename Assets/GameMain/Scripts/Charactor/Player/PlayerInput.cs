using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject
{
    public class PlayerInput : MonoBehaviour
    {
        
        SkillList m_SkillList;
        public void Awake()
        {
            
            m_SkillList = GetComponent<SkillList>();
        }

        public void ReleaseSkill(int skillIdx)
        {
            m_SkillList.ReleaseSkill(skillIdx);
        }
    }
}
