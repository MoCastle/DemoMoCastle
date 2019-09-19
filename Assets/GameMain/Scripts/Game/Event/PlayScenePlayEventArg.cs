using System.Collections;
using System.Collections.Generic;
using FrameWork;
using UnityEngine;
namespace GameProject
{

    public class PlayScenePlayEventArg : FrameWorkEventArg
    {
        public int playID { get; private set; }
        public PlayScenePlayEventArg(int id)
        {
            playID = id;
        }
    }

}