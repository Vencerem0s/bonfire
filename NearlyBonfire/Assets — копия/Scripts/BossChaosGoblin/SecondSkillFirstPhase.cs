using UnityEngine;

namespace BossChaosGoblin
{
    public class SecondSkillFirstPhase : BossBehaviour
    {
        private Boss _boss;

        public void Enter()
        {
            Debug.Log("ENTER SecondSkillFistPhase");
        }

        public void Exit()
        {
            Debug.Log("EXIT SecondSkillFistPhase");
        }

        public void Update()
        {

        }

        public SecondSkillFirstPhase(Boss boss)
        {
            _boss = boss;
        }
    }
}

