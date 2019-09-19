using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using GameProject.PlayerModule;
using GameProject.TimeLine;
using GameProject;
using FrameWork;
using UnityEngine.Timeline;

namespace GameProject
{
    public class ScenePlayDirector : BaseSceneDirector
    {
        [SerializeField]
        PlayableDirectorControler CurDirector;

        int m_CurPlayID;

        protected override void OnPlaySceenPlay(object sender, FrameWorkEventArg arg)
        {
            base.OnPlaySceenPlay(sender, arg);
            PlayScenePlayEventArg playArg = arg as PlayScenePlayEventArg;
            int idx = playArg.playID;
            CurDirector = transform.GetChild(idx).GetComponent<PlayableDirectorControler>();
            CurDirector.Init(idx);
            CurDirector.Play();
        }
        //private void Update()
        //{
        //    if (CurDirector.time >= CurDirector.duration)
        //    {
        //        Debug.Log(CurDirector.duration - CurDirector.time);
        //        GameControler.singleton.eventManager.FireEvent(this,new PlayCompleteEventArg(m_CurPlayID));
        //        gameObject.active = false;
        //    }
        //    //Debug.Log(CurDirector.duration);
        //}
    }
}
