using System.Collections;
using System.Collections.Generic;
using GameProject.UI;
using UnityEngine;
namespace GameProject{
    public class BuffElementAgent : IAgentScrollElemetInfos
    {
        List<BaseCharactorBuff> m_BuffList;
        public BuffElementAgent(List<BaseCharactorBuff> buffList)
        {
            m_BuffList = buffList;
        }

        public object GetElementInfo(int idx)
        {
            return m_BuffList[idx];
        }

        public int GetInfoCount()
        {
            return m_BuffList.Count;
        }

        public ScrollElement SetItemInfo(ScrollElement element)
        {
            BuffElement elementForm = element.script as BuffElement;
            elementForm.SetBuff(m_BuffList[element.idx]);
            return element;
        }
    }
}
