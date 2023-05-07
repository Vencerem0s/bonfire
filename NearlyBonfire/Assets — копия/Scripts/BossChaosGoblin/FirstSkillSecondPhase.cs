using System;
using UnityEngine;

namespace BossChaosGoblin
{
    public class FirstSkillSecondPhase : BossBehaviour
    {
        private Boss _boss;

        public void Enter()
        {
            Debug.Log("ENTER FirstSkillSecondPhase");
        }

        public void Exit()
        {
            Debug.Log("EXIT FirstSkillSecondPhase");
        }

        public void Update()
        {

        }

        public FirstSkillSecondPhase(Boss boss)
        {
            _boss = boss;
        }
    }
}

