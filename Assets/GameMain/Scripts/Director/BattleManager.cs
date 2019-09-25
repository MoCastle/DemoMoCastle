using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;
using GameProject.Director;
using GameProject.PlayerModule;
using GameProject.TimeLine;
namespace GameProject
{
    public class BattleManager : BaseGameManager<BattleManager>
    {
        public BaseActor player;
        public BaseActor enemy;

        [SerializeField]
        BattleUI m_BTUI;
        [SerializeField]
        UIInput m_Input;

        bool m_GameContinue;
        bool m_GameEnd;
        BattleDirector m_Director;

        #region 流程
        private void Start()
        {
            m_Director = GetComponent<BattleDirector>();
            player.Init();
            enemy.Init();

            m_BTUI.Init();
            m_Input.Init();

            GameControler.singleton.eventManager.FireEvent<SceneEnteredArg>(this, null);
            Pause();
            player.OnChampionFallDown = OnChampionFall;
            enemy.OnChampionFallDown = OnChampionFall;
        }

        private void GameEnd()
        {
            m_GameEnd = true;
            Pause();

            int progress = Player.singleton.questManager.GetQuestProgress(0);
            if(progress == 1)
            {
                GameControler.singleton.eventManager.RegistEvent<PlayCompleteEventArg>(EndGame);
                if (player.propty.life > 0)
                {
                    WinGame();
                    GameControler.singleton.eventManager.FireEvent<ChampionFallArg>(enemy, null);
                }
                else
                {
                    LostGame();
                }
            }else
            {
                EndGame(null, null);
            }
            
        }

        private void WinGame()
        {
            m_Director.PlayScenePlay(2);
        }

        private void LostGame()
        {
            m_Director.PlayScenePlay(1);
        }

        void EndGame(object sender,FrameWorkEventArg arg)
        {
            GameControler.singleton.eventManager.UnRegistEvent<PlayCompleteEventArg>(EndGame);
            GameControler.EnterChoseLevelScene();
        }
        #endregion
        #region 战斗
        public void StartBattle()
        {
            m_GameEnd = false;
            StartFight();
        }

        public void Pause()
        {
            PauseFight();
        }

        public void Continue()
        {
            ContinueFight();
        }

        #endregion
        private void OnDestroy()
        {
        }
        #region 战斗
        public void StartFight()
        {
            player.Init();
            enemy.Init();
        }

        public void PauseFight()
        {
            player.gameObject.active = false;
            enemy.gameObject.active = false;
        }

        public void ContinueFight()
        {
            player.gameObject.active = true;
            enemy.gameObject.active = true;
        }
        #endregion
        #region 角色
        void OnChampionFall(BaseActor champion)
        {
            GameEnd();
        }
        #endregion
    }
}
