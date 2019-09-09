using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject.AI{
	public class BaseComposites : AITreeNode {
        protected List<AITreeNode> m_Nodes;
        protected override void OnInit()
        {
            base.OnInit();
            LoopInit();
        }

        protected override void OnAwake()
        {
            AITreeNode[] treeNodes = new AITreeNode[transform.childCount];
            base.OnAwake();
            for (int nodeEnumIdx = 0; nodeEnumIdx < treeNodes.Length; ++nodeEnumIdx)
            {
                AITreeNode node = transform.GetChild(nodeEnumIdx).GetComponent<AITreeNode>();
                treeNodes[nodeEnumIdx] = node;
            }
            m_Nodes = new List<AITreeNode>();
            m_Nodes.AddRange(treeNodes);
        }

        public void LoopInit()
        {
            foreach (AITreeNode node in m_Nodes)
            {
                node.Init(m_Tree);
            }
        }
    }
}
