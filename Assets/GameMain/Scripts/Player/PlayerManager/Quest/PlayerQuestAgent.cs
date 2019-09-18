using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameProject.PlayerModule.Quest;

namespace GameProject.PlayerModule
{
    public class PlayerQuestAgent : BasePlayerAgent
    {
        
        Dictionary<int, BaseQuest> m_QuestDict;

        public PlayerQuestAgent()
        {
            m_QuestDict = new Dictionary<int, BaseQuest>();
        }

        public void RunQuest()
        {
            
        }

        public override void Init()
        {
            base.Init();
            DefaultQuest mainQuest = new DefaultQuest();
            AddQuest(mainQuest);
        }

        void AddQuest(BaseQuest quest)
        {
            m_QuestDict.Add(quest.id, quest);
            quest.Start();
        }

    }
}
