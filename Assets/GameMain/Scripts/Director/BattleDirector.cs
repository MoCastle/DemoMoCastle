using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;
namespace GameProject
{
    public class BattleDirector : BaseDirector<BattleDirector>
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
        }

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
