using UnityEngine;

public class SecondSkillBehaviour : IPlayerBehaviour
{
    private Dwarf _dwarf;

    public void Enter()
    {
        _dwarf.SetAnimation("SecondSkill");
    }

    public void Exit()
    {
        Debug.Log("SecondSkill EXIT");
    }

    public SecondSkillBehaviour(Dwarf dwarf)
    {
        _dwarf = dwarf;
    }
}