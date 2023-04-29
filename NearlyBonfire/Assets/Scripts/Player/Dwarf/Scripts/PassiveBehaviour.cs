using System.Collections;
using UnityEngine;

public class PassiveBehaviour : IPlayerBehaviour
{
    private Dwarf _dwarf;
    private Coroutine _coroutine;

    public void Enter()
    {
        //установить анимацию
        _dwarf.SetDwarfValues(0.7f, 0.3f);
        if (_coroutine != null)
            return;
        _coroutine = CoroutinesStarterBehaviour.StartRoutine(Passive());

    }

    public void Exit()
    {
        CoroutinesStarterBehaviour.StopRoutine(_coroutine);
        _coroutine = null;
        _dwarf.SetDwarfValues(1 / 0.7f, 0.9f);
        Debug.Log("EXIT passive");
    }

    public PassiveBehaviour(Dwarf dwarf)
    {
        _dwarf = dwarf;
    }

    private IEnumerator Passive()
    {
        yield return new WaitForSeconds(2f);
       
    }
}