using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameProject;
using FrameWork;
namespace GameProject.Director
{
    public class BaseDirector<T> : MonoBehaviour where T:BaseDirector<T>
    {
        public static T singleton { get; private set; }
        private void Awake()
        {
            singleton = this as T;
            OnAwake();
            GameControler.singleton.eventManager.RegistEvent<GameStopEventArg>(OnGameStop);
            GameControler.singleton.eventManager.RegistEvent<OnLeaveSceneEventArg>(OnLeaveScene);
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

        }
        protected virtual void OnPlaySceenPlay(object sender, FrameWorkEventArg arg)
        {
        }
    }
}
