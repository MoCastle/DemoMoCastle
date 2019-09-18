using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

namespace GameProject.TimeLine
{
    public class PlayCompleteEventArg : FrameWorkEventArg
    {
        public int id { get; private set; }
        public PlayCompleteEventArg(int playID)
        {
            id = playID;
        }
    }
}
