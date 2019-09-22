using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrameWork;

namespace GameProject
{

    public class UIInput : MonoBehaviour
    {
        [SerializeField]
        Text battleInfo;
        public Slider playerLife;
        public Slider enemeyLife;

        public BaseActor player
        {
            get
            {
                return BattleManager.singleton.player;
            }
        }
        public BaseActor enemy
        {
            get
            {
                return BattleManager.singleton.enemy;
            }
        }

        private void Update()
        {
            playerLife.value = player.propty.lifePercent;
            enemeyLife.value = enemy.propty.lifePercent;
        }
        public void Init()
        {
            battleInfo.text = "";
            EventManager evMgr = GameControler.singleton.eventManager;
            evMgr.RegistEvent<BattleInfoArg>(OnGetMessage);
        }
        public void OnDestroy()
        {
            GameControler.singleton.eventManager.UnRegistEvent<BattleInfoArg>(OnGetMessage);
        }

        public void  OnGetMessage(object sender, FrameWorkEventArg arg)
        {
            BattleInfoArg battleArg = arg as BattleInfoArg;
            battleInfo.text = battleArg.Message + "\n\n" + battleInfo.text;
        }
    }
}
