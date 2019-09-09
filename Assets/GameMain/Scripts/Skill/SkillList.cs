using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{

    public class SkillList : MonoBehaviour
    {
        SkillFsm m_SkillFsm;
        public SkillStruct[] skillStruct;
        BaseActor m_Plaer;
        BaseActor m_Target;

        public float countTime
        {
            get
            {
                BaseSkillState skill = m_SkillFsm.curSkillState;
                float theCounttime;
                theCounttime = skill.countTime;
                return theCounttime;
            }
        }

        public float totalTime
        {
            get
            {
                BaseSkillState skill = m_SkillFsm.curSkillState;
                return skill.totalTime;
            }
        }

        public BaseSkillState curSkillState
        {
            get
            {
                return m_SkillFsm.curSkillState;
            }
        }

        private void Awake()
        {
            m_Plaer = GetComponent<BaseActor>();
            m_Target = m_Plaer.Target;
            m_SkillFsm = new SkillFsm(this);
        }

        private void Update()
        {
            m_SkillFsm.Update();
        }

        public SkillStruct GetSkill(int idx)
        {
            return skillStruct[idx];
        }

        public void ReleaseSkill(int skillIdx)
        {
            if ((m_SkillFsm.curSkillState.skillInfo.type != SkillType.NotReleaseSkill && countTime > 0))
            {
                return;
            }
            SkillStruct skillStuct = GetSkill(skillIdx);

            BaseSkillState newSkillState = null;
            if(skillStuct.skillClassName == "")
            {
                newSkillState = new BaseSkillState(this, skillStuct, m_Target);
            }else
            {
                Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集
                Type GetState = assembly.GetType("GameProject." + skillStuct.skillClassName);
                newSkillState = (BaseSkillState)Activator.CreateInstance(GetState, new object[] { this, skillStuct, m_Target }); // 创建类的
            }
            m_SkillFsm.SetState(newSkillState);
        }
    }
}
