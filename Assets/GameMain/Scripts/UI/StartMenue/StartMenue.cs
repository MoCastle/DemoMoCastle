using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameProject.PlayerModule;
     
namespace GameProject{
	public class StartMenue : MonoBehaviour {
        public void StartGame()
        {
            Player.singleton.Init();
            GameControler.StartGame();
        }
    }
}
