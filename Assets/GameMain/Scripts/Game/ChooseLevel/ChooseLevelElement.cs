using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject{
	public class ChooseLevelElement : MonoBehaviour {
        int m_Idx;
        public void Init(int idx)
        {
            m_Idx = idx;
        }
        public void JumpScene()
        {
            GameControler.EnterBattleScene(m_Idx);
        }
	}
}
