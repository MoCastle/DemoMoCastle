using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject.PlayerModule.Quest{
	public abstract class BaseQuest {
        public int id { get; protected set; }
        public bool locked { get; protected set; }
        abstract public void Start();
        abstract public void Update();
        abstract public void CompleteProgress();
	}
}
