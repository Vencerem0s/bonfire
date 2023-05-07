using System;
using UnityEngine;

namespace BossChaosGoblin
{
    public class SecondSkillSecondPhase : BossBehaviour
    {
        private Boss _boss;

        public void Enter()
        {
            Debug.Log("ENTER SecondSkillSecondPhase");
        }

        public void Exit()
        {
            Debug.Log("EXIT SecondSkillSecondPhase");
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public SecondSkillSecondPhase(Boss boss)
        {
            _boss = boss;
        }
    }
}

