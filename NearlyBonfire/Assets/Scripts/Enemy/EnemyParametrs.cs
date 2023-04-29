/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;*/

public class EnemyParametrs : LiveParametrs
{
    protected EnemyMovement _animationDeath;

    protected override void Start()
    {
        base.Start();
        GameEventManger.BloodDamage += TakeDamage;
        _animationDeath = GetComponent<EnemyMovement>();
    }

    protected override void Update()
    {
        if (health <= 0)
        {
            GameObjectsManager.Unregister(gameObject);
            _animationDeath.gAnimator.SetBool("Die", true);
        }
    }

    public override void TakeDamage(string typeDamage, float damage)
    {
        base.TakeDamage(typeDamage, damage);
        GameEventManger.BloodHeal?.Invoke(damage - mageResist);
    }

    protected virtual void DeathInAnimation()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameEventManger.BloodDamage -= TakeDamage;
    }
}
