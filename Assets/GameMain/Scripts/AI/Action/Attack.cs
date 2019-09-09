using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject.AI{
	public class Attack : BaseAction
    {
        
        protected override TreeNodeState InternalUpdate()
        {
            m_SkillList.ReleaseSkill(0);
            return TreeNodeState.success;
        }
    }
}
