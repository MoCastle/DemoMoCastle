using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

namespace GameProject{
	public class GameControler : BaseBehaviourSingleton<GameControler> {
        FrameWorkManager m_FrameWorkManager;
        public EventManager eventManager
        {
            get
            {
                return GetManager<EventManager>();
            }
        }
        public SceneFrameManager sceneManager
        {
            get
            {
                return GetManager<SceneFrameManager>();
            }
        }

        public GameControler()
        {
            m_FrameWorkManager = new FrameWorkManager();
            m_FrameWorkManager.Init();
        }

        private void Awake()
        {
            GameObject.DontDestroyOnLoad(this);
        }

        public T GetManager<T>() where T: BaseManager
        {
            return m_FrameWorkManager.GetManager<T>();
        }
        #region 游戏控制
        public static void StartGame()
        {
            singleton.sceneManager.JumpScene("PlayableScene");
        }
        #endregion

    }
}
