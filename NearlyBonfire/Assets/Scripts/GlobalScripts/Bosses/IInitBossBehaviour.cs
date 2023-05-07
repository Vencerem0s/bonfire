using System;
using System.Collections.Generic;

public interface IInitBossBehaviour
{
    //Dictionary<Type, BossBehaviour> InitBehaviours(Boss boss);
    void InitBehaviours(Boss boss);
    BossBehaviour GetBehaviour<T>() where T : BossBehaviour;
    BossBehaviour SetFirstSkillFirstPhase();
    BossBehaviour SetSecondSkillFirstPhase();
    BossBehaviour SetFirstSkillSecondPhase();
    BossBehaviour SetSecondSkillSecondPhase();
    BossBehaviour SetPhaseChange();

}

