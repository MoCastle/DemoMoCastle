using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameProject
{
    public class BaseActor : MonoBehaviour
    {
        public Action<BaseActor> OnChampionFallDown;
        public Action OnBuffChange;

        protected BuffAgent m_BuffAgent;
        public BaseActor Target;

        [SerializeField]
        CharactorPropty m_Propty;

        string m_OutPutName;
        public string outPutName
        {
            get
            {
                if(m_OutPutName == null)
                {
                    m_OutPutName = "< color =#00ffffff>"+m_Propty.name+"</color>";
                }
                return m_OutPutName;
            }
        }

        public delegate void OnGetNewProgress(string newMessage);
        public OnGetNewProgress OnNewProgresss;
        public CharactorPropty propty
        {
            get
            {
                return m_Propty;
            }
        }
        public SkillList skillList
        {
            get;
            private set;
        }
        #region 流程
        public void Init()
        {
            m_BuffAgent = GetComponent<BuffAgent>();
            skillList = GetComponent<SkillList>();
            m_Propty.Reset();

            m_BuffAgent.Init();
        }
        #endregion
        #region 属性
        int DeductLife(int value)
        {
            m_Propty.life -= value;
            if(m_Propty.life<0)
            {
                m_Propty.life = 0;
            }
            return m_Propty.life;
        }

        public void GetHurt(int value)
        {
            if (value < 0)
            {
                Debug.LogWarning("WrongHurtValue");
                return;
            }
            if (m_Propty.GetIsEgnoreEffectMarked(EgnoreEffect.Hurt))
                return;
            OnNewProgresss("受到" + value + "点伤害");
            BattleInfoArg arg = new BattleInfoArg();
            arg.Message = m_Propty.name + "受到" + value + "点伤害";
            GameControler.singleton.eventManager.FireEvent<BattleInfoArg>(this, arg);
            
            if ( DeductLife(value)<=0)
            {
                arg.Message = m_Propty.name + "死亡";
                GameControler.singleton.eventManager.FireEvent<BattleInfoArg>(this, arg);
                OnChampionFallDown(this);
            }

        }

        public void LostBallance(int value)
        {
            skillList.curSkillState.lostBanlanceValue += value;
        }

        public void AddEgnoreLayer(params EgnoreEffect[] arr)
        {
            foreach(EgnoreEffect layer in arr)
            {
                m_Propty.AddEgnore(layer);
            }
        }

        public void RemoveEgnoreLayer(params EgnoreEffect[] arr)
        {
            foreach (EgnoreEffect layer in arr)
            {
                m_Propty.RemoveEgnore(layer);
            }
        }
        #endregion
        #region Buff
        public void AddBuff(BaseCharactorBuff buff)
        {
            m_BuffAgent.AddBuff(buff);
            if (OnBuffChange != null)
                OnBuffChange();
        }

        public void RemoveBuff(BaseCharactorBuff buff)
        {
            m_BuffAgent.RemoveBuff(buff);
            if (OnBuffChange != null)
                OnBuffChange();
        }

        public List<BaseCharactorBuff> GetBuffList()
        {
            return m_BuffAgent.GetBuffList();
        }
        #endregion
        #region 输出

        #endregion
    }

}
