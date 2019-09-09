using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject.AI
{
    public class TreeQueue : BaseComposites
    {
        IEnumerator<AITreeNode> m_NodeEnumerator;
        bool m_Waiting;
        protected override void OnInit()
        {
            base.OnInit();
            m_NodeEnumerator = m_Nodes.GetEnumerator();
        }

        protected override void OnStart()
        {
            base.OnStart();
            m_NodeEnumerator.Reset();
            m_Waiting = false;
        }
        protected override TreeNodeState InternalUpdate()
        {
            if (m_Waiting || m_NodeEnumerator.MoveNext())
            {
                m_Waiting = true;
                if (!m_NodeEnumerator.Current.Started)
                {
                    m_NodeEnumerator.Current.StartNode();
                    
                }else
                {
                    if (m_NodeEnumerator.Current.UpdateNode() != TreeNodeState.running)
                    {
                        m_NodeEnumerator.Current.Complete();
                        m_Waiting = false;
                    }
                }
                
                return TreeNodeState.running;
            }
            else
                return TreeNodeState.success;
        }
    }
}
