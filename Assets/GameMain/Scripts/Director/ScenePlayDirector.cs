using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace GameProject.ScenePlay
{
    public class ScenePlayDirector : MonoBehaviour
    {
        PlayableDirector CurDirector;
        private void Start()
        {
            OnStart();
        }

        void OnStart()
        {
            if(CurDirector != null)
            {
                CurDirector.Play();
            }
        }

        private void Update()
        {
            //if(CurDirector.time>=CurDirector.)
        }
    }
}
