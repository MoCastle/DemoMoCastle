using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{
    public class BattleSceneDirector : MonoBehaviour
    {
        public BaseActor player;
        public BaseActor enemy;

        static BattleSceneDirector m_Singleton;
        public static BattleSceneDirector singleton
        {
            get
            {
                return m_Singleton;
            }
            set
            {
                m_Singleton = value;
            }
        }

        private void Awake()
        {
            m_Singleton = this;
        }
    }
}
