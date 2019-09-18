using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FrameWork;
using GameProject.TimeLine;
namespace GameProject.PlayerModule.Quest
{
    public class DefaultQuest : BaseQuest
    {
        public int progress { get; private set; }

        public DefaultQuest():base()
        {
            //GameControler.singleton.eventManager.RegistEvent<PlayCompleteEventArg>(OnPlayComplete);
            //GameControler.singleton.eventManager.RegistEvent<ChampionFallArg>(OnChampionDown);
            id = 0;
        }

        public override void Start()
        {
            GameControler.singleton.eventManager.RegistEvent<SceneEnteredArg>((sendObj, sceneEnterAgrg) => { if (SceneManager.GetActiveScene().name == "Battle") { PushProgress(); } });
        }

        public override void Update()
        {

        }

        public void OnRemoved()
        {

        }

        public override void CompleteProgress()
        {
            ++progress;
            
        }

        void PushProgress()
        {
            switch(progress)
            {
                case 0:
                    GameControler.singleton.eventManager.FireEvent<StopGameEventArg>(this, null);
                    break;
                case 1:
                    break;
            }
        }

        public void OnPlayComplete(object sender,FrameWorkEventArg arg)
        {
            PlayCompleteEventArg playArg = arg as PlayCompleteEventArg;
            if(playArg.id==0)
            {
                CompleteProgress();
                PushProgress();
            }
        }

        public void OnChampionDown(object sendr,FrameWorkEventArg arg)
        {
            CompleteProgress();
        }
    }
}
