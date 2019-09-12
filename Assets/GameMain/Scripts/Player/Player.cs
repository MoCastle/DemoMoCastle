using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject.PlayerModule
{
    public class Player : BaseBehaviourSingleton<Player>
    {
        Dictionary<string, BasePlayerManager> m_ManagerDict;
        public PlayerQuestManager questManager
        {
            get
            {
                return GetPlayerManger<PlayerQuestManager>();
            }
        }
        Player()
        {
            m_ManagerDict = new Dictionary<string, BasePlayerManager>();

            AddManager(new PlayerQuestManager());
        }
        void AddManager<T>( T mgr ) where T:BasePlayerManager
        {
            m_ManagerDict.Add(typeof(T).Name, mgr);
        }

        public T GetPlayerManger<T>()where T:BasePlayerManager
        {
            return m_ManagerDict[typeof(T).Name] as T;
        }
    }
}
