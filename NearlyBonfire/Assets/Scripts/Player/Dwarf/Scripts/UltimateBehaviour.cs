using System.Collections;
using UnityEngine;

public class UltimateBehaviour : IPlayerBehaviour
{
    private Dwarf _dwarf;
    private Coroutine _coroutine;

    public void Enter()
    {
        if (_coroutine != null)
            return;
        _coroutine = CoroutinesStarterBehaviour.StartRoutine(Ultimate());
        _dwarf.SetUltimate(true);
        _dwarf.SetDwarfValues(2f, 100f, 40f, 2f);
        _dwarf.SetAnimation("Ultimate");
    }

    public void Exit()
    {
        CoroutinesStarterBehaviour.StopRoutine(_coroutine);
        _coroutine = null;
        _dwarf.SetDwarfValues(0.5f, 0f, -40f, 0f);
        //_dwarf.DoExitBehaviour();
        _dwarf.SetUltimate(false);
    }

    public UltimateBehaviour(Dwarf dwarf)
    {
        _dwarf = dwarf;
    }

    private IEnumerator Ultimate()
    {
        yield return new WaitForSeconds(10f);
        Exit();
    }

}