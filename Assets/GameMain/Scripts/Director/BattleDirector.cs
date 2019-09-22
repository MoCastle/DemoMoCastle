using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;
using GameProject.TimeLine;
namespace GameProject{
	public class BattleDirector : BaseSceneDirector {
        BattleManager m_BattleManager;

        protected override void OnStart()
        {
            base.OnStart();
            m_BattleManager = GetComponent<BattleManager>();
            int idx = (GameControler.singleton.sceneManager.GetSceneData("BattleScene") as int?) ??0;
            InternalPlaySceenPlay(idx);
            GameControler.singleton.eventManager.RegistEvent<PlayCompleteEventArg>(InternalStartBattle);
        }

        void InternalStartBattle(object sender,FrameWorkEventArg arg)
        {
            m_BattleManager.StartBattle();
            GameControler.singleton.eventManager.UnRegistEvent<PlayCompleteEventArg>(InternalStartBattle);
        }
    }
}
