using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameProject.PlayScene;
using FrameWork;

namespace GameProject{
	public class PlaySceneUI : MonoBehaviour {
        [SerializeField]
        GameObject clickCheck;
        private void Awake()
        {
            //GameControler.singleton.eventManager.RegistEvent<ContinuePlayEventArg>(OnPlayContinue);
        }
        public void OnPlayContinue(object sender,FrameWorkEventArg arg)
        {
           // clickCheck.active = false;
        }
        public void OnMouseClick()
        {
            GameControler.singleton.eventManager.FireEvent<MouseClickEventArg>(this,null);
            clickCheck.active = false;
        }
	}
}
