using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{
    public class BuffAgent : BaseActorAgent
    {
        List<BaseCharactorBuff> m_BuffList;

        public override void Init()
        {
            base.Init();
            m_BuffList = new List<BaseCharactorBuff>();
        }

        private void Update()
        {
            BaseCharactorBuff[] buffList = m_BuffList.ToArray();
            foreach (BaseCharactorBuff buff in buffList)
            {
                buff.Update();
            }
        }
        public void AddBuff(BaseCharactorBuff buff)
        {
            buff.Start();
            m_BuffList.Add(buff);
        }
        public void RemoveBuff(BaseCharactorBuff buff)
        {
            buff.End();
            m_BuffList.Remove(buff);
        }
        public List<BaseCharactorBuff> GetBuffList()
        {
            return m_BuffList;
        }
    }
}
