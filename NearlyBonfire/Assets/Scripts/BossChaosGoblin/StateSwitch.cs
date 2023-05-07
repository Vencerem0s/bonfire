using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossChaosGoblin
{
    public class StateSwitch : IInitBossBehaviour
    {

        private Dictionary<Type, BossBehaviour> _behaviourMap;

        public void InitBehaviours(Boss boss)
        {
            _behaviourMap = new Dictionary<Type, BossBehaviour>();

            _behaviourMap[typeof(FirstSkillFirstPhase)] = new FirstSkillFirstPhase(boss);
            _behaviourMap[typeof(SecondSkillFirstPhase)] = new SecondSkillFirstPhase(boss);
            _behaviourMap[typeof(FirstSkillSecondPhase)] = new FirstSkillSecondPhase(boss);
            _behaviourMap[typeof(SecondSkillSecondPhase)] = new SecondSkillSecondPhase(boss);
            _behaviourMap[typeof(PhaseChange)] = new PhaseChange(boss);
        }

        public BossBehaviour GetBehaviour<T>() where T : BossBehaviour
        {
            var type = typeof(T);
            return _behaviourMap[type];
        }

        public BossBehaviour SetFirstSkillFirstPhase()
        {
            var behaviour = GetBehaviour<FirstSkillFirstPhase>();
            return behaviour;
        }

        public BossBehaviour SetSecondSkillFirstPhase()
        {
            var behaviour = GetBehaviour<SecondSkillFirstPhase>();
            return behaviour;
        }

        public BossBehaviour SetFirstSkillSecondPhase()
        {
            var behaviour = GetBehaviour<FirstSkillSecondPhase>();
            return behaviour;
        }

        public BossBehaviour SetSecondSkillSecondPhase()
        {
            var behaviour = GetBehaviour<SecondSkillSecondPhase>();
            return behaviour;
        }
        public BossBehaviour SetPhaseChange()
        {
            var behaviour = GetBehaviour<PhaseChange>();
            return behaviour;
        }
    }
}
