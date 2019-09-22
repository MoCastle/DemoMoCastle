using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;
using GameProject.TimeLine;

namespace GameProject
{
    public abstract class BaseSceneDirector : MonoBehaviour
    {
        protected PlayableDirectorControler m_CurDirector;

        private void Awake()
        {
            OnAwake();
            GameControler.singleton.eventManager.RegistEvent<GameStopEventArg>(OnGameStop);
            GameControler.singleton.eventManager.RegistEvent<OnLeaveSceneEventArg>(OnLeaveScene);
            GameControler.singleton.eventManager.RegistEvent<PlayScenePlayEventArg>(OnPlaySceenPlay);
        }
        private void Start()
        {
            OnStart();
            GameControler.singleton.eventManager.FireEvent<SceneStartedArg>(this);
        }
        protected virtual void OnStart()
        {
        }

        protected virtual void OnAwake() { }
        protected virtual void OnGameStop(object sender, FrameWorkEventArg arg)
        {
        }
        protected virtual void OnLeaveScene(object sender, FrameWorkEventArg arg)
        {
            GameControler.singleton.eventManager.UnRegistEvent<GameStopEventArg>(OnGameStop);
            GameControler.singleton.eventManager.UnRegistEvent<OnLeaveSceneEventArg>(OnLeaveScene);
            GameControler.singleton.eventManager.UnRegistEvent<PlayScenePlayEventArg>(OnPlaySceenPlay);
        }

        protected virtual void OnPlaySceenPlay(object sender, FrameWorkEventArg arg)
        {
            PlayScenePlayEventArg playArg = arg as PlayScenePlayEventArg;
            int idx = playArg.playID;
            InternalPlaySceenPlay(idx);
        }

        protected void InternalPlaySceenPlay(int idx)
        {
            m_CurDirector = transform.GetChild(idx).GetComponent<PlayableDirectorControler>();
            m_CurDirector.gameObject.active = true;
            m_CurDirector.Init(idx);
            m_CurDirector.Play();
        }
    }
}
