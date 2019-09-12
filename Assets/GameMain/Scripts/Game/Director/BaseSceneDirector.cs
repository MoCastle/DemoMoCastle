using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject{
	public abstract class BaseSceneDirector : MonoBehaviour {
        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {

        }
        
        // Use this for initialization
        void Start () {
            GameControler.singleton.eventManager.RegistEvent<OnLeaveSceneEventArg>(OnLeaveScene);
            OnStart();
        }

        protected virtual void OnStart()
        {

        }
	
		// Update is called once per frame
		void Update () {
			
		}

        protected virtual void OnLeaveScene(object sender,OnLeaveSceneEventArg arg)
        {
            GameControler.singleton.eventManager.UnRegistEvent<OnLeaveSceneEventArg>(OnLeaveScene);
        }

	}
}
