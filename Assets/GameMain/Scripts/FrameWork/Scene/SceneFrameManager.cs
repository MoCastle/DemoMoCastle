using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace FrameWork
{
    public class SceneFrameManager : BaseManager
    {
        Dictionary<string, object> m_SceneDatas;
        EventManager m_EventManager;
        EventManager eventManager
        {
            get
            {
                if (m_EventManager == null)
                    m_EventManager = m_FrameWorkManager.GetManager<EventManager>();
                return m_EventManager;
            }
        }
        public bool isRunningScene { get;private set; }
        public SceneFrameManager(FrameWorkManager inFrameWorkManager):base(inFrameWorkManager)
        {
            m_SceneDatas = new Dictionary<string, object>();
        }

        public void JumpScene(string name,object data = null)
        {
            eventManager.FireEvent<JumpSceneEventArg>(this,null);
            if(data !=null)
                m_SceneDatas[name] = data;
            SceneManager.LoadScene(name);
        }

        public object GetSceneData(string name)
        {
            object data = null;
            m_SceneDatas.TryGetValue(name,out data);
            return data;
        }
    }
}
