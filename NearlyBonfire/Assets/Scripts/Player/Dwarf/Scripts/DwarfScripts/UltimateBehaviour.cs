using System.Threading.Tasks;
using UnityEngine;

public class UltimateBehaviour : IPlayerBehaviour
{
    private Dwarf _dwarf;
    private GameObject[] _ax;
    private GameObject[] _shield;
    private int _numberAttack;

    public void Enter()
    {
        _dwarf.SetAnimation("Ultimate");
        
        _dwarf.SetDwarfValues(range: 100f, axDamage: 40f, shieldDamage: 40f);
        _numberAttack = 1;
        WaitEndUltimate();
    }

    public void Exit()
    {
        _dwarf.SetDwarfValues();
        _dwarf.ExitFromUltimate();
    }

    public void Update()
    {
        if (_dwarf._chAnimator.GetCurrentAnimatorStateInfo(1).IsName("axAttack") || _dwarf._chAnimator.GetCurrentAnimatorStateInfo(2).IsName("firstSkill"))
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _dwarf.SetAnimation(SetUltimateAttack(_numberAttack));
            _numberAttack++;
        }
    }

    public UltimateBehaviour(Dwarf dwarf)
    {
        _dwarf = dwarf;
    }

    #region PRIVATE METHODS

    private async void WaitEndUltimate()
    {
        await Task.Delay(10000);
        Exit();
    }


    private string SetUltimateAttack(int numberAttack)
    {
        return numberAttack % 2 == 0 ? "StAttack" : "FirstSkill";
    }
    #endregion

}