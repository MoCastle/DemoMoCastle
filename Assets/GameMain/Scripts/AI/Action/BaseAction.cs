using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject.AI{
	public abstract class BaseAction : AITreeNode
    {
        protected SkillList m_SkillList;

        protected override void OnInit()
        {
            m_SkillList = m_Tree.npc.GetComponent<SkillList>();

        }
    }
}
