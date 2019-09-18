using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using GameProject;
using GameProject.PlayerModule;
using GameProject.TimeLine;

namespace GameProject.ScenePlay
{
    public class ScenePlayDirector : MonoBehaviour
    {
        [SerializeField]
        PlayableDirector CurDirector;

        int m_CurPlayID;

        private void Awake()
        {
            string sceneName = SceneManager.GetActiveScene().name;
            m_CurPlayID = (GameControler.singleton.sceneManager.GetSceneData(sceneName)as int?)?? 0;
        }

        private void Start()
        {
            OnStart();
        }

        void OnStart()
        {
            if (CurDirector != null)
            {
                CurDirector.Play();
            }
        }

        private void Update()
        {
            if (CurDirector.time >= CurDirector.duration)
            {
                Debug.Log(CurDirector.duration - CurDirector.time);
                GameControler.singleton.eventManager.FireEvent(this,new PlayCompleteEventArg(m_CurPlayID));
            }
            //Debug.Log(CurDirector.duration);
        }
    }
}
