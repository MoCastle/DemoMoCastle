using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{
    [Serializable]
    public struct SkillStruct
    {
        public string name;
        public string outPutName { get { return "<color=#0000ffff> " + name + "</color>"; } }
        //public string outPutName { get { return name; } }

        public SkillType type;
        public int hurt;
        public float releaseTime;
        public float interruptValue;
        public float lostBalandceLine;
        public float lostBalanceTime;
        public int selfBuff;
        public int enemyBuff;
        public string skillClassName;
    }
}
