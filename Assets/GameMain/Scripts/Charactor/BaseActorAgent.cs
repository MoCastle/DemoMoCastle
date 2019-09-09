using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{
    public abstract class BaseActorAgent : MonoBehaviour
    {
        public BuffStruct[] buffStructList;
        protected BaseActor m_Actor;

        public virtual void Init()
        {
            m_Actor = GetComponent<BaseActor>();
        }
    }
}
