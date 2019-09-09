using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameProject
{
    public class BattleUI : MonoBehaviour
    {
        public CharactorUI[] uis;

        public CharactorUI playerUI
        {
            get
            {
                return uis[0];
            }
        }
        public CharactorUI enemyUI
        {
            get
            {
                return uis[1];
            }
        }

        public void Init()
        {
            BattleDirector dir = BattleDirector.singleton;
            playerUI.Init(dir.player);
            enemyUI.Init(dir.enemy);
        }
    }
}
