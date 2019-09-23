using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{
    public class BaseSkillState:FsmState
    {
        float m_TimeStamp;
        protected SkillStruct m_SkillStruct;
        protected SkillList m_SkillList;
        protected BaseActor m_BaseTarget;
        protected BaseActor m_SelfActor;

        public float lostBanlanceValue
        {
            get;
            set;
        }
        protected SkillType skillType
        {
            get
            {
                return m_SkillStruct.type;
            }
        }
        public SkillStruct skillInfo
        {
            get
            {
                return m_SkillStruct;
            }
        }
        public float countTime
        {
            get
            {
                return m_TimeStamp - Time.time;
            }
        }
        public float totalTime
        {
            get
            {
                return m_SkillStruct.releaseTime;
            }
        }

        public BaseSkillState(SkillList skillList,SkillStruct skillStruct,BaseActor targetActor = null)
        {
            m_SkillList = skillList;
            m_SkillStruct = skillStruct;
            m_BaseTarget = targetActor;
            m_SelfActor = m_SkillList.GetComponent<BaseActor>();
        }

        public override void Start()
        {
            base.Start();
            BattleInfoArg battleInfo = new BattleInfoArg();
            if(skillType != SkillType.NotReleaseSkill)
                battleInfo.Message = GenMessage();
            GameControler.singleton.eventManager.FireEvent(this, battleInfo);
            lostBanlanceValue = 0;
            CountTime(m_SkillStruct.releaseTime);
        }

        protected virtual string GenMessage()
        {
            return skillType == SkillType.HurtEffect ? m_SelfActor.propty.name + "被绊倒" : m_SelfActor.propty.name + " 对 " + m_BaseTarget.propty.name + "使用" + m_SkillStruct.name;
        }

        public override void Update()
        {
            base.Update();
            if(m_SkillStruct.releaseTime > 0)
            {
                if (m_TimeStamp < Time.time)
                {
                    OnLeaveStopping();
                }
            }
            if(lostBanlanceValue > m_SkillStruct.lostBalandceLine)
            {
                EnterLostBallance();
            }
        }

        protected void CountTime(float time)
        {
            m_TimeStamp = Time.time + time;
        }

        protected virtual void OnEnterReleasing() { }
        protected virtual void OnLeaveReleasing() { }
        protected virtual void OnEnterEffecting() { }
        protected virtual void OnLeaveEffecting() { }
        protected virtual void OnEnterStopping() { }
        protected virtual void OnLeaveStopping()
        {
            EffectSkill();
            SkillStruct nothingDo = new SkillStruct();
            nothingDo.type = SkillType.NotReleaseSkill;
            BaseSkillState nothingToDoState = new BaseSkillState(m_SkillList, nothingDo);
            owner.SetState(nothingToDoState);
        }
        protected virtual void EffectSkill()
        {
            if (m_BaseTarget == null)
                return;
            m_BaseTarget.GetHurt(m_SkillStruct.hurt);
            m_BaseTarget.LostBallance((int)m_SkillStruct.interruptValue);
        }
        protected virtual void EnterLostBallance()
        {
            SkillStruct lostBallance = new SkillStruct();
            lostBallance.type = SkillType.HurtEffect;
            lostBallance.releaseTime = m_SkillStruct.lostBalanceTime;
            lostBallance.name = "摔倒";
            BaseSkillState lostBallanceState = new BaseSkillState(m_SkillList, lostBallance);
            owner.SetState(lostBallanceState);

        }
    }
}
