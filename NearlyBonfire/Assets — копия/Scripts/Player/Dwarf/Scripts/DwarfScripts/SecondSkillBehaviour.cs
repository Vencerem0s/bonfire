using UnityEngine;

public class SecondSkillBehaviour : IPlayerBehaviour
{
    private Dwarf _dwarf;
    private GameObject[] _ax;

    public void Enter()
    {
        _dwarf.SetDwarfValues(range: -10f, axDamage: 60f);
        _dwarf.SetAnimation("SecondSkill");
    }

    public void Exit()
    {
        _dwarf.SetDwarfValues();
    }

    public void Update()
    {

    }

    public SecondSkillBehaviour(Dwarf dwarf)
    {
        _dwarf = dwarf;
    }


    #region PRIVATE METHODS
  
    #endregion
}