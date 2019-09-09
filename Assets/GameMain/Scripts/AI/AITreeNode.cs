using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject.AI
{
	public class AITreeNode : MonoBehaviour {
        
        protected AITree m_Tree;

        public bool Started
        {
            get
            {
                return gameObject.active;
            }
        }

        private void Awake()
        {
            
            gameObject.active = false;
            OnAwake();
        }

        public void StartNode()
        {
            OnStart();
            gameObject.active = true;
        }

        public void Init(AITree tree)
        {
            m_Tree = tree;
            OnInit();
            gameObject.active = false;
        }

        protected virtual void OnInit()
        {
        }

        
        protected virtual void OnAwake()
        {

        }
        protected virtual void OnStart()
        {

        }

        public TreeNodeState UpdateNode()
        {
            if(!gameObject.active)
            {
                StartNode();
                return TreeNodeState.running;
            }
            return InternalUpdate();
        }

        virtual protected TreeNodeState InternalUpdate()
        {
            return TreeNodeState.success;
        }

        public void Complete()
        {
            OnComplete();
            gameObject.active = false;
        }

        protected virtual void OnComplete()
        {

        }
    }
}
