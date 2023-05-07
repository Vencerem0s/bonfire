using UnityEngine;

namespace BossChaosGoblin
{
    public class FirstSkillFirstPhase : BossBehaviour
    {
        private Boss _boss;

        public void Enter()
        {
            Debug.Log("ENTER FirstSkillFirstPhase");
        }

        public void Exit()
        {
            Debug.Log("EXIT FirstSkillFirstPhase");
        }

        public void Update()
        {

        }

        public FirstSkillFirstPhase(Boss boss)
        {
            _boss = boss;
        }
    }
}




