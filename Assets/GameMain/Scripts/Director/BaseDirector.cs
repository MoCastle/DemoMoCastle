using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{
    public class BaseDirector<T> : MonoBehaviour where T:BaseDirector<T>
    {
        public static T singleton { get; private set; }
        private void Awake()
        {
            singleton = this as T;
            OnAwake();
        }
        protected virtual void OnAwake() { }
    }
}
