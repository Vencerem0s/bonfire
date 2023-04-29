using UnityEngine;

public class StAttackBehaviour : IPlayerBehaviour
{
    private Dwarf _dwarf;
    private GameObject[] _ax;

    public void Enter()
    {
        _dwarf.SetAnimation("StAttack");
    }

    public void Exit()
    {
        Debug.Log("StAttack EXIT");
    }

    public void Update()
    {

    }

    public StAttackBehaviour(Dwarf dwarf)
    {
        _dwarf = dwarf;
    }
}