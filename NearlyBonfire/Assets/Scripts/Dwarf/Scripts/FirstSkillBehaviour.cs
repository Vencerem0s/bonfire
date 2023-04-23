using UnityEngine;

public class FirstSkillBehaviour : IPlayerBehaviour
{
    private Dwarf _dwarf;

    public void Enter()
    {
        _dwarf.SetAnimation("FirstSkill");
    }

    public void Exit()
    {
        Debug.Log("FirstSkill EXIT");
    }

    public FirstSkillBehaviour(Dwarf dwarf)
    {
        _dwarf = dwarf;
    }
}