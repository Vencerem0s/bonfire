using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageParametrs : PlayerParametrs
{

    protected override void Start()
    {
        base.Start();
        GameEventManger.BloodHeal += TakeHealth;
    }

    public override void TakeHealth(float _healthPoint)
    {
        base.TakeHealth(_healthPoint);
        GetComponent<Mage>().TakeMana(5f);
    }

    private void OnDestroy()
    {
        GameEventManger.BloodHeal -= TakeHealth;
    }
}
