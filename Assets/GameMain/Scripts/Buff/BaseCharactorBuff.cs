using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{
    public class BaseCharactorBuff
    {
        protected BaseActor m_EffectActor;
        protected float time { get; set; }
        public int idx { get; private set; }
        float m_TimeStamp;
        public float timeValue
        {
            get
            {
                return (Time.time - m_TimeStamp) / time;
            }
        }

        public BaseCharactorBuff(int inIdx,float inTime,BaseActor effectActor)
        {
            idx = inIdx;
            time = inTime;
            m_EffectActor = effectActor;
            m_TimeStamp = Time.time;
        }

        public void Update()
        {
            if(m_TimeStamp + time < Time.time)
            {
                m_EffectActor.RemoveBuff(this);
            }
        }

        public virtual void Start()
        {

        }

        public virtual void End()
        {
        }
    }
}
