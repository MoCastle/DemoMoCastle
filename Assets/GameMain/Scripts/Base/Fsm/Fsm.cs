using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject{
	public class Fsm {
        protected FsmState m_CurState;
        public void SetState(FsmState state)
        {
            if (m_CurState != null)
                m_CurState.End();
            m_CurState = state;
            m_CurState.owner = this;
            m_CurState.Start();
        }
        public void Update()
        {
            m_CurState.Update();
        }
	}
}
