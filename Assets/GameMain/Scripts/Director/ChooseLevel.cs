using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject{
	public class ChooseLevel : MonoBehaviour {

		// Use this for initialization
		void Start () {
            int childNum = transform.childCount;

            for (int childIdx = 0; childIdx < childNum;++childIdx)
            {
                Transform trans = transform.GetChild(childIdx);
                LevelChooseBtn btn = trans.gameObject.AddComponent<LevelChooseBtn>();
                btn.Init(childIdx);
            }
		}
	}
}
