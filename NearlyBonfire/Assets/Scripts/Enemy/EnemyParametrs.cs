using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParametrs : LiveParametrs
{

    protected override void Start()
    {
        base.Start();
        GameEventManger.BloodDamage += TakeDamage;
    }

    public override void TakeDamage(string typeDamage, float damage)
    {
        base.TakeDamage(typeDamage, damage);
        GameEventManger.BloodHeal?.Invoke(damage - mageResist);
    }

    private void OnDestroy()
    {
        GameEventManger.BloodDamage -= TakeDamage;
    }
}
