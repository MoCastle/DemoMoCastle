using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject.PlayerModule.Quest{
	public abstract class BaseQuest {
        public virtual int progress { get; protected set; }
        public int id { get; protected set; }
        public bool locked { get; protected set; }
        abstract public void StartNewQuest();
        abstract public void Update();
        abstract public void CompleteProgress();
	}
}
