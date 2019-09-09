using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject.UI.Scroll
{

    public class HorizontalBarAgetn : BaseScrollBarAgent
    {
        ScrollRect m_ScrollRect;
        Scrollbar m_ScrollBar;
        IconState m_IconState;

        public override bool isDragging
        {
            get
            {
                return (m_IconState != null && m_IconState.isPressed) ? true : false;
            }
        }

        public override void Init(BaseScrollRect scrollRect)
        {
            base.Init(scrollRect);
            m_ScrollRect = scrollRect.GetComponent<ScrollRect>();
            m_ScrollBar = m_ScrollRect.horizontalScrollbar;
            if (m_ScrollBar != null)
            {
                IconState m_IconState = m_ScrollBar.GetComponent<IconState>();
                if (m_IconState == null)
                {
                    m_IconState = m_ScrollBar.gameObject.AddComponent<IconState>();
                }
            }
        }
    }

}