using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject
{

    public class SkillListElement : MonoBehaviour
    {
        public int idx;
        public Transform player;
        Text m_Text;
        SkillList m_SkillList;
        PlayerInput m_PlayerInput;
        private void Awake()
        {
            m_Text = transform.GetChild(0).GetComponent<Text>();
            m_SkillList = player.GetComponent<SkillList>();
            m_PlayerInput = player.GetComponent<PlayerInput>();
            m_Text.text = m_SkillList.GetSkill(idx).name;
        }

        public void OnClick()
        {
            m_PlayerInput.ReleaseSkill(idx);
        }
    }
}
