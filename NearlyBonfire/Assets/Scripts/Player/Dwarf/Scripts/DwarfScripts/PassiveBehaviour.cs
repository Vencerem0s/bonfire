using UnityEngine;

public class PassiveBehaviour : IPlayerBehaviour
{
    private Dwarf _dwarf;

    public void Enter()
    {
        //установить анимацию
        _dwarf.SetDwarfValues(speedMove:0.7f, armor:0.7f);
    }

    public void Exit()
    {
        _dwarf.SetDwarfValues(speedMove:1 / 0.7f);
        Debug.Log("EXIT passive");
    }

    public void Update()
    {

    }

    public PassiveBehaviour(Dwarf dwarf)
    {
        _dwarf = dwarf;
    }

}