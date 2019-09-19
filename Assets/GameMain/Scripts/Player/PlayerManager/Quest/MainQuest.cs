using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FrameWork;
using GameProject.TimeLine;
using GameProject;
namespace GameProject.PlayerModule.Quest
{
    public class MainQuest : BaseQuest
    {
        public int progress { get; private set; }

        public MainQuest() : base()
        {
            //GameControler.singleton.eventManager.RegistEvent<PlayCompleteEventArg>(OnPlayComplete);
            //GameControler.singleton.eventManager.RegistEvent<ChampionFallArg>(OnChampionDown);
            id = 0;
        }

        public override void Start()
        {
            GameControler.singleton.eventManager.RegistEvent<SceneStartedArg>(EnterMainQuest);
        }
        void EnterMainQuest(object sendObj, FrameWorkEventArg sceneEnterAgrg)
        {
            if (SceneManager.GetActiveScene().name == "PlayableScene")
            {
                PushProgress();
            }
            GameControler.singleton.eventManager.UnRegistEvent<SceneStartedArg>(EnterMainQuest);
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
            switch (progress)
            {
                case 0:
                    GameControler.singleton.eventManager.FireEvent<PlayScenePlayEventArg>(this, new PlayScenePlayEventArg(0));
                    break;
                case 1:
                    break;
            }
        }

        public void OnPlayComplete(object sender, FrameWorkEventArg arg)
        {
            PlayCompleteEventArg playArg = arg as PlayCompleteEventArg;
            if (playArg.id == 0)
            {
                CompleteProgress();
                PushProgress();
            }
        }

        public void OnChampionDown(object sendr, FrameWorkEventArg arg)
        {
            CompleteProgress();
        }
    }
}
