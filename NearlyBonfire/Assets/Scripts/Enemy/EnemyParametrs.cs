/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;*/

public class EnemyParametrs : LiveParametrs
{
    protected EnemyMovement _animationDeath;

    protected override void Start()
    {
        base.Start();
        //GameEventManger.BloodDamage += TakeDamage;
        GameEventManger.BloodDamage += TakeBloodDamage;
        _animationDeath = GetComponent<EnemyMovement>();
    }

    protected override void Update()
    {
        if (health <= 0)
        {
            _animationDeath.gAnimator.SetBool("Die", true);
        }
    }

    public override void TakeDamage(string typeDamage, float damage)
    {
        base.TakeDamage(typeDamage, damage);
        //GameEventManger.BloodHeal?.Invoke(damage - mageResist);
    }

    public virtual void TakeBloodDamage(string typeDamage, float damage)
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
        GameObjectsManager.Unregister(gameObject);
        GameEventManger.BloodDamage -= TakeDamage;
    }
}
