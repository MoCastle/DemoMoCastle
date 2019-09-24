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
            MainQuest mainQuest = new MainQuest();
            AddQuest(mainQuest);
        }

        void AddQuest(BaseQuest quest)
        {
            m_QuestDict.Add(quest.id, quest);
            quest.StartNewQuest();
        }
        #region 任务
        public BaseQuest GetBaseQuest(int idx)
        {
            return m_QuestDict[idx];
        }

        public T GetBaseQuest<T>(int idx) where T:BaseQuest
        {
            return m_QuestDict[idx] as T;
        }

        public int GetQuestProgress(int idx)
        {
            BaseQuest quest = m_QuestDict[idx];
            return quest.progress;
        }
        #endregion
    }
}
