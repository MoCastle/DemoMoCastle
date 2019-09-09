using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject.AI
{

    public class AITree : MonoBehaviour
    {
        [Header("开始时运行")]
        [SerializeField]
        public bool runWhenStart;
        [Header("完成后重新开始")]
        [SerializeField]
        public bool repeat;

        public BaseActor npc
        {
            get;
            private set;
        }

        AITreeNode startNode;

        bool running;
        private void Awake()
        {
            startNode = transform.GetChild(0).GetComponent<AITreeNode>();
            npc = transform.parent.GetComponent<BaseActor>();
        }
        private void Start()
        {
            InitNodes();
            if(runWhenStart)
            {
                running = true;
                
            }
        }
        private void Update()
        {
            if(running)
            {
                if(!startNode.Started)
                {
                    startNode.StartNode();
                    return;
                }
                TreeNodeState state = startNode.UpdateNode();
                switch (state)
                {
                    case TreeNodeState.running:
                        return;
                        break;
                    default:
                        running = false;
                        startNode.Complete();
                        break;
                }
                if(repeat && !running)
                {
                    running = true;
                }
            }
        }
        private void InitNodes()
        {
            startNode.Init(this);
        }
    }
}
