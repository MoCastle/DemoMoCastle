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
        int targetEnemyIdx;
        public int progress { get; private set; }

        public MainQuest() : base()
        {
            //GameControler.singleton.eventManager.RegistEvent<PlayCompleteEventArg>(OnPlayComplete);
            //GameControler.singleton.eventManager.RegistEvent<ChampionFallArg>(OnChampionDown);
            id = 0;
        }

        public override void StartNewQuest()
        {
            PushProgress();
        }
        #region 进入游戏
        void EnterMainQuest(object sendObj, FrameWorkEventArg sceneEnterAgrg)
        {
            if (SceneManager.GetActiveScene().name == "PlayableScene")
            {
                GameControler.singleton.eventManager.UnRegistEvent<SceneStartedArg>(EnterMainQuest);
                GameControler.singleton.eventManager.FireEvent<PlayScenePlayEventArg>(this,new PlayScenePlayEventArg(0));
                GameControler.singleton.eventManager.RegistEvent<PlayCompleteEventArg>(GamePlaySceneEnd);
            }
        }

        void GamePlaySceneEnd(object sendObj, FrameWorkEventArg endArg)
        {
            CompleteProgress();
            PlayCompleteEventArg playEndArg = endArg as PlayCompleteEventArg;
            if(playEndArg.id == 0)
            {
                GameControler.singleton.eventManager.UnRegistEvent<PlayCompleteEventArg>(GamePlaySceneEnd);
                PushProgress();
            }
        }
        #endregion

        #region 怪物
        void OnEnterBattlePlayScnePlay(object sender, FrameWorkEventArg arg)
        {
            BaseActor champion = sender as BaseActor;
            if(champion.propty.name == "测试怪")
            {
                GameControler.singleton.eventManager.FireEvent<PlayScenePlayEventArg>(this, new PlayScenePlayEventArg(1));
                GameControler.singleton.eventManager.UnRegistEvent<ChampionFallArg>(OnEnterBattlePlayScnePlay);
                CompleteProgress();
                PushProgress();
            }
        }

        #endregion
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
                    GameControler.singleton.eventManager.RegistEvent<SceneStartedArg>(EnterMainQuest);
                    break;
                case 1:
                    GameControler.EnterChoseLevelScene();
                    GameControler.singleton.eventManager.RegistEvent<ChampionFallArg>(OnEnterBattlePlayScnePlay);
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
