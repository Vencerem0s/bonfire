using UnityEngine;

public class FirstSkillBehaviour : IPlayerBehaviour
{
    private Dwarf _dwarf;
    private GameObject[] _shield;

    public void Enter()
    {
        _dwarf.SetAnimation("FirstSkill");
        _dwarf.SetDwarfValues(range:20f, stunTime:5f);
    }

    public void Exit()
    {
        _dwarf.SetDwarfValues();
    }

    public void Update()
    {

    }

    public FirstSkillBehaviour(Dwarf dwarf)
    {
        _dwarf = dwarf;
    }

    #region PRIVATE METHODS

    #endregion

}