using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameProject.UI;

namespace GameProject
{
    public class BuffElement : BaseScrollFormElement
    {
        BaseCharactorBuff buff;
        Image m_image;

        public void SetBuff(BaseCharactorBuff inBuff)
        {
            buff = inBuff;
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            m_image = GetComponent<Image>();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            m_image.fillAmount = 1- buff.timeValue;
        }

        public override void Despawn()
        {
        }
    }
}
