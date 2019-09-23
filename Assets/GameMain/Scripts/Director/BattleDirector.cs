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
            m_BattleManager.Continue();
            GameControler.singleton.eventManager.UnRegistEvent<PlayCompleteEventArg>(InternalStartBattle);
        }
        protected override void InternalPlaySceenPlay(int idx)
        {
            base.InternalPlaySceenPlay(idx);
            m_BattleManager.Pause();
        }
    }
}
