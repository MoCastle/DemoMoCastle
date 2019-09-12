using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject.PlayerModule
{
    public class PlayerQuestManager : BasePlayerManager
    {
        public int curQuestID { get; private set; }
        public QuestData curQuestData
        {
            get
            {
                return m_QuestDict[curQuestID];
            }
        }
        Dictionary<int, QuestData> m_QuestDict;

        public PlayerQuestManager()
        {
            m_QuestDict = new Dictionary<int, QuestData>();
            curQuestID = 0;
        }

        public void RunQuest()
        {
            Debug.Log("StartQuest");
        }

        public void OnAddProgress()
        {

        }
    }
}
