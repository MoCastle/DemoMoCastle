using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

namespace GameProject{
	public class GameControler : BaseBehaviourSingleton<GameControler> {
        Dictionary<string, BaseManager> m_ManagerDict;
        public EventManager eventManager
        {
            get
            {
                return GetManager<EventManager>();
            }
        }

        public GameControler()
        {
            m_ManagerDict = new Dictionary<string, BaseManager>();
            AddManager(new EventManager());
        }

        private void Awake()
        {
            GameObject.DontDestroyOnLoad(this);
        }

        void AddManager<T>(T manager) where T: BaseManager
        {
            string name = typeof(T).Name;
            m_ManagerDict.Add(name, manager);
        }

        public T GetManager<T>() where T: BaseManager
        {
            string name = typeof(T).Name;
            BaseManager manager = null;
            m_ManagerDict.TryGetValue(name,out manager);
            return manager as T;
        }
	}
}
