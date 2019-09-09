using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject.AI{
	public class WaitAttackCD: BaseAction
    {
        protected override void OnInit()
        {
            base.OnInit();
        }
        protected override TreeNodeState InternalUpdate()
        {
            if(m_SkillList.countTime >0)
            {
                return TreeNodeState.running;
            }
            return TreeNodeState.success;
        }
    }
}
