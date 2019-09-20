using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectBase;
using UnityEngine.Playables;
namespace GameProject
{
    public class ScenePlaySingleton : BaseBehaviourSingleton<ScenePlaySingleton>
    {
        Transform trans;

        public ScenePlaySingleton()
        {
            trans = new GameObject("TimeLine").transform;
            trans.SetParent(this.transform);
            trans.gameObject.active = false;
        }

        public void PlayDirector(string name)
        {
            trans.gameObject.active = true;
            for(int idx = 0;idx <trans.childCount;++idx)
            {
                GameObject.Destroy( trans.GetChild(idx).gameObject);
            }
            PlayableDirector playable = Resources.Load<PlayableDirector>(name);
            playable.Play();
        }

        private void Update()
        {
            if (!trans.gameObject.active)
                return;

        }
    }
}
