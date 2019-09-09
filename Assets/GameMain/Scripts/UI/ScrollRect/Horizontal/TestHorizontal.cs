using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameProject.UI;
namespace GameProject
{

    public class TestHorizontal : MonoBehaviour
    {
        public ExtendUGUIScroll rect;
        public int jumpto = 3;
        // Use this for initialization
        void Start()
        {
            int[] testInfo = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            rect.Init(new DefaultElementInfoAgent(testInfo));
        }

        public void JumpTo()
        {
            rect.JumpTo(jumpto);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}