using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GameProject.UI.Scroll;

namespace GameProject.UI
{

    public class FormHorizontalScrollRect : BaseScrollRect, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        Vector3[] m_ViewAnchorsInContentPos;
        Vector3[] m_ItemAchorsInContentPos;
        RectTransform m_ViewRect;
        ScrollRect m_ScrollRect;
        UGUIScrollBounceData m_BounceData;
        [SerializeField]
        float m_MinScrollSpeed = 0;
        [SerializeField]
        float m_BounceBackTime = 1;

        #region 流程
        protected override void OnInit()
        {
            base.OnInit();
            m_ViewAnchorsInContentPos = new Vector3[4];
            m_ItemAchorsInContentPos = new Vector3[4];
            m_ScrollRect = GetComponent<ScrollRect>();
            m_ViewRect = m_ScrollRect.viewport.GetComponent<RectTransform>();
            m_ElementContainer = m_ScrollRect.content.GetComponent<RectTransform>();
            Reset();
        }

        #endregion
        #region 位置换算
        protected void CountItemAnchorsPosOnContentPositon(Vector3[] anchors, RectTransform icon)
        {
            icon.GetWorldCorners(anchors);
            for (int idx = 0; idx < anchors.Length; ++idx)
            {
                anchors[idx] = m_ElementContainer.InverseTransformPoint(anchors[idx]);
            }
        }
        protected float CountCeneterPos()
        {
            CountItemAnchorsPosOnContentPositon(m_ViewAnchorsInContentPos, m_ViewRect);
            float centerPos = (m_ViewAnchorsInContentPos[0].x + m_ViewAnchorsInContentPos[2].x) / 2;
            return centerPos;
        }

        #endregion
        #region 功能
        protected override bool scrolling
        {
            get
            {
                if (m_ScrollRect.velocity.sqrMagnitude > Mathf.Pow(m_MinScrollSpeed,2))
                {
                    return true;
                }
                return false;
            }
        }
        private Vector3 bounceSpeed;
        protected override void OnScroll()
        {
            CountItemAnchorsPosOnContentPositon(m_ViewAnchorsInContentPos, m_ViewRect);
            base.OnScroll();
        }
        protected override void Bounce()
        {
            float centerPos = CountCeneterPos();

            ScrollElement element = m_ShowingElements[GetCenterNearlyElement()];
            float dist = centerPos - m_SampleElement.rect.width / 2 - element.rect.localPosition.x;
            Vector3 targetPos = m_ElementContainer.localPosition;
            targetPos.x += dist;
            Vector3 finalyPos = new Vector3();
            finalyPos = Vector3.SmoothDamp(m_ElementContainer.localPosition, targetPos, ref bounceSpeed, m_BounceBackTime);
            m_ElementContainer.localPosition = finalyPos;
        }


        public void Reset()
        {
            float with = m_ElementsAgent.GetInfoCount() * (m_SampleElement.rect.width + m_SpaceBTElements) - m_SpaceBTElements;
            Vector2 size = m_ElementContainer.sizeDelta;
            size.x = with;
            m_ElementContainer.sizeDelta = size;
            IEnumerator<ScrollElement> chipsEnumerator = m_ShowingElements.GetEnumerator();
            chipsEnumerator.Reset();
            while (chipsEnumerator.MoveNext())
            {
                DisPawnElement(chipsEnumerator.Current);
            }
            m_ShowingElements.Clear();
            int headIdx = CountHeadIdx();
            if (headIdx < m_ElementsAgent.GetInfoCount() - 1)
            {
                ScrollElement headElement = SpawnElement();
                AddHead(headElement);
            }
        }
        public float CountPosByIdx(int idx)
        {
            float pos = idx * (m_SampleElement.rect.width + m_SpaceBTElements);
            return pos;
        }
        public int CountHeadIdx()
        {
            int idx = 0;
            CountItemAnchorsPosOnContentPositon(m_ViewAnchorsInContentPos, m_ViewRect);
            float dis = m_ViewAnchorsInContentPos[0].x;
            idx = dis > 0 ? (int)Mathf.Floor(dis / (m_SampleElement.rect.width + m_SpaceBTElements)) : 0;
            return idx;
        }
        #endregion
        #region 元素管理
        protected override bool IsNeedAddHead()
        {
            if (showingElementsNum <= 0)
                return true;
            ScrollElement headElement = m_ShowingElements[0];
            if (headElement.idx <= 0)
                return false;
            CountItemAnchorsPosOnContentPositon(m_ItemAchorsInContentPos, headElement.rect);
            if (m_ViewAnchorsInContentPos[0].x < m_ItemAchorsInContentPos[0].x)
            {
                return true;
            }
            return false;
        }

        protected override bool IsNeedAddTail()
        {
            ScrollElement tailElement = m_ShowingElements[showingElementsNum - 1];
            if (tailElement.idx >= m_ElementsAgent.GetInfoCount() - 1)
                return false;
            CountItemAnchorsPosOnContentPositon(m_ItemAchorsInContentPos, tailElement.rect);
            if (m_ViewAnchorsInContentPos[2].x > m_ItemAchorsInContentPos[2].x)
            {
                return true;
            }
            return false;
        }

        protected override bool IsOutHeadBounce()
        {
            ScrollElement headElement = m_ShowingElements[0];
            CountItemAnchorsPosOnContentPositon(m_ItemAchorsInContentPos, headElement.rect);
            if (m_ViewAnchorsInContentPos[0].x > m_ItemAchorsInContentPos[2].x)
            {
                return true;
            }
            return false;
        }

        protected override bool IsOutTailBounce()
        {
            ScrollElement tailElement = m_ShowingElements[showingElementsNum - 1];
            CountItemAnchorsPosOnContentPositon(m_ItemAchorsInContentPos, tailElement.rect);
            if (m_ViewAnchorsInContentPos[2].x < m_ItemAchorsInContentPos[0].x)
            {
                return true;
            }
            return false;
        }

        protected override ScrollElement RemoveElementFromShoing(int Idx)
        {
            ScrollElement removedElement = m_ShowingElements[Idx];
            m_ShowingElements.RemoveAt(Idx);
            return removedElement;
        }

        protected override void AddHead(ScrollElement headElement)
        {
            if (showingElementsNum > 0)
            {
                ScrollElement perHeadEleemnt = m_ShowingElements[0];
                headElement = InitScrollElement(headElement, perHeadEleemnt.idx - 1);

                Vector3 anchorPositon = perHeadEleemnt.rect.anchoredPosition;
                anchorPositon.x -= m_SampleElement.rect.width + m_SpaceBTElements;
                headElement.rect.anchoredPosition = anchorPositon;
                m_ShowingElements.Insert(0, headElement);
            }
            else
            {
                int headIdx = CountHeadIdx();
                headElement = InitScrollElement(headElement, headIdx);
                Vector3 newPosition = headElement.rect.anchoredPosition;
                newPosition.x = CountPosByIdx(headIdx);
                headElement.rect.anchoredPosition = newPosition;
                m_ShowingElements.Insert(0, headElement);
            }
        }

        protected override void AddTail(ScrollElement tailElement)
        {
            ScrollElement perTailEleemnt = m_ShowingElements[showingElementsNum - 1];
            tailElement = InitScrollElement(tailElement, perTailEleemnt.idx + 1);

            Vector3 anchorPositon = perTailEleemnt.rect.anchoredPosition;
            anchorPositon.x += m_SampleElement.rect.width + m_SpaceBTElements;
            tailElement.rect.anchoredPosition = anchorPositon;
            m_ShowingElements.Add(tailElement);

        }
        #endregion

        void UpdateBouncingDataf()
        {
            if (m_BounceData.state == BounceState.Bouncing)
            {

            }
        }

        protected override int GetCenterNearlyElement()
        {
            float centerPos = CountCeneterPos();
            ScrollElement element = m_ShowingElements[0];
            int midleIdx = 0;
            float startPos = element.rect.localPosition.x;
            float elementWidth = m_SampleElement.rect.width;
            float elementSpace = elementWidth + m_SpaceBTElements;

            float lastDst = 999999999999999999;

            for (int idx = 0; idx < m_ShowingElements.Count; ++idx)
            {
                float elementCeneter = startPos + elementWidth / 2;
                float countDst = Mathf.Abs(centerPos - elementCeneter);
                
                if (countDst < lastDst)
                {
                    lastDst = countDst;
                    midleIdx = idx;
                    startPos += elementSpace;
                }
                else
                {
                    break;
                }
            }
            return midleIdx;
        }
        #region 拖动
        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
        }
        #endregion

    }

}