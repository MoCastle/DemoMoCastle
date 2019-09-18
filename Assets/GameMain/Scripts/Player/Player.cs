using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject.PlayerModule
{
    public class Player : BaseBehaviourSingleton<Player>
    {
        Dictionary<string, BasePlayerAgent> m_ManagerDict;
        public PlayerQuestAgent questManager
        {
            get
            {
                return GetPlayerManger<PlayerQuestAgent>();
            }
        }
        Player()
        {
            m_ManagerDict = new Dictionary<string, BasePlayerAgent>();

            AddManager(new PlayerQuestAgent());
        }

        public void Init()
        {
            foreach(BasePlayerAgent agent in m_ManagerDict.Values)
            {
                agent.Init();
            }
        }

        void AddManager<T>( T mgr ) where T:BasePlayerAgent
        {
            m_ManagerDict.Add(typeof(T).Name, mgr);
        }

        public T GetPlayerManger<T>()where T:BasePlayerAgent
        {
            return m_ManagerDict[typeof(T).Name] as T;
        }
    }
}
