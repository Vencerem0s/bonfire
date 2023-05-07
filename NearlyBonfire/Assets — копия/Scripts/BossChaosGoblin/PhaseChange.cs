using System;
using UnityEngine;

namespace BossChaosGoblin
{
    public class PhaseChange : BossBehaviour
    {
        private Boss _boss;

        public void Enter()
        {
            Debug.Log("ENTER PhaseChange");
            _boss.ChangePhaseNumber();
        }

        public void Exit()
        {
            _boss.SetPhaseAnim(_boss._phaseNumber);
        }

        public void Update()
        {

        }

        public PhaseChange(Boss boss)
        {
            _boss = boss;
        }
    }
}

