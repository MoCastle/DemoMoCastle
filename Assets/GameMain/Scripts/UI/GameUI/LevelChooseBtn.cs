using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject{
	public class LevelChooseBtn : MonoBehaviour {

        public int idx { get;private set; }

        public void Init(int inIdx)
        {
            idx = inIdx;
        }
        public void OnClickBtn()
        {
            GameControler.EnterBattleScene(idx);
        }
	}
}
