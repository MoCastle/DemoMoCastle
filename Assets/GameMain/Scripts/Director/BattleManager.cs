using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;
using GameProject.Director;
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

        private void Start()
        {
            player.Init();
            enemy.Init();

            m_BTUI.Init();
            m_Input.Init();

            GameControler.singleton.eventManager.FireEvent<SceneEnteredArg>(this, null);
            GameControler.singleton.eventManager.RegistEvent<ChampionFallArg>(GameEnd);
            player.gameObject.active = false;
            enemy.gameObject.active = false;
        }
        #region 战斗
        public void StartBattle()
        {
            player.gameObject.active = true;
            enemy.gameObject.active = true;
        }

        #endregion
        private void OnDestroy()
        {
            GameControler.singleton.eventManager.UnRegistEvent<ChampionFallArg>(GameEnd);
        }

        private void GameEnd(object sender,FrameWorkEventArg arg)
        {
            enemy.gameObject.active = false;
            player.gameObject.active = false;

            if (player.propty.life > 0)
            {
                WinGame();
            }
            else
            {
                LostGame();
            }
        }

        private void WinGame()
        {
        }

        private void LostGame()
        {

        }
    }
}
