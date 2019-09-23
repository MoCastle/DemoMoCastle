using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject
{
    [Serializable]
    public struct CharactorPropty
    {
        public int maxLife;
        public int life;
        public int atk;
        public int effectLayer;
        public string name;
        int[] m_LayerArr;

        public void init()
        {
            life = maxLife;
            m_LayerArr = new int[(int)EgnoreEffect.End];
        }
        public float lifePercent
        {
            get
            {
                float percent = (float)life / maxLife;
                return percent;
            }
        }
        public void AddEgnore(EgnoreEffect effect)
        {
            ++m_LayerArr[(int)effect];
        }
        public void RemoveEgnore(EgnoreEffect effect)
        {
            --m_LayerArr[(int)effect];
            m_LayerArr[(int)effect] = m_LayerArr[(int)effect] < 0 ? 0 : m_LayerArr[(int)effect];
        }
        public bool GetIsEgnoreEffectMarked(EgnoreEffect effect)
        {
            return m_LayerArr[(int)effect] > 0 ;
        }
    }
}

