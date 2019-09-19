using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameProject;
using UnityEngine.Playables;

namespace GameProject.TimeLine
{

    public class PlayableDirectorControler : MonoBehaviour
    {
        public bool played { get; private set; }
        PlayableDirector director;
        int idx;
        private void Awake()
        {
            gameObject.active = false;
            //GameControler.singleton.eventManager.fir
            director = GetComponent<PlayableDirector>();
        }
        public void Init(int inIdx)
        {
            idx = inIdx;
        }
        public void Play()
        {
            played = true;
            director.Play();
        }
        private void Update()
        {
            if(played)
            {
                if(director.time >= director.duration)
                {
                    GameControler.singleton.eventManager.FireEvent<PlayCompleteEventArg>(this, new PlayCompleteEventArg(idx));
                    gameObject.active = false;
                }
            }
        }

    }

}