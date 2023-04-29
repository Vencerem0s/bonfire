using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParametrs : LiveParametrs
{

    public virtual void TakeHealth(float _healthPoint)
    {
        if ((health + _healthPoint) >= maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += _healthPoint;
        }
    }
}
