using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameProject.UI;

namespace GameProject{
	public class CharactorUI : MonoBehaviour {
        BaseActor m_Actor;
        public Text txt;
        public Slider slider;
        bool m_Inited;
        BaseSkillState m_CurSkillState;
        [SerializeField]
        Text m_Progress;
        [SerializeField]
        ExtendUGUIScroll m_BuffScroll;
        private void Awake()
        {
            m_Inited = false;
        }
        public void Init( BaseActor actor )
        {
            m_Actor = actor;
            m_Inited = true;
            m_Actor.OnNewProgresss += NewProgress;
            m_BuffScroll.Init(new BuffElementAgent(m_Actor.GetBuffList()));
            m_Actor.OnBuffChange += () => { m_BuffScroll.Reset();  };
        }
	
		// Update is called once per frame
		void Update () {
			if(m_Inited)
            {
                BaseSkillState curSkillState = m_Actor.skillList.curSkillState;
                if(m_CurSkillState!=curSkillState)
                {
                    m_CurSkillState = curSkillState;
                    if (m_CurSkillState==null || m_CurSkillState.skillInfo.type == SkillType.NotReleaseSkill)
                    {
                        txt.text = "";
                        slider.gameObject.active = false;
                    }else
                    {
                        txt.text = m_CurSkillState.skillInfo.outPutName;
                        slider.gameObject.active = true;
                    }
                }
                if (m_CurSkillState == null)
                    return;

                float skillTime = (float)m_Actor.skillList.countTime;
                float totalTime = (float)m_Actor.skillList.totalTime;
                float slideValue = totalTime > 0 ? (skillTime / totalTime) : 0;
                slider.value = slideValue;

            }
		}

        #region UI显示
        public void NewProgress(string progress)
        {
            m_Progress.text = progress;
        }
        #endregion
    }
}
