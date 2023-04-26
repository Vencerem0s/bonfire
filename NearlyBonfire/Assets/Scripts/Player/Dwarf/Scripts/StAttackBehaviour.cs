using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StAttackBehaviour : IPlayerBehaviour
{
    private Dwarf _dwarf;

    public void Enter()
    {
        _dwarf.SetAnimation("StAttack");
    }

    public void Exit()
    {
        Debug.Log("StAttack EXIT");
    }

    public StAttackBehaviour(Dwarf dwarf)
    {
        _dwarf = dwarf;
    }
}