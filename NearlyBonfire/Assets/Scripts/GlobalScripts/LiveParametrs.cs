using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveParametrs : MonoBehaviour
{
    public float health, maxHealth, armor, mageResist;

    protected virtual void Start()
    {
        GameObjectsManager.Register(gameObject);
        maxHealth = health;
    }
    public virtual void TakeDamage(string typeDamage,float damage)
    {
        switch (typeDamage)
        {
            case "physical":
                health -= (damage - armor);
                break;

            case "magical":
                health -= (damage - mageResist);
                break;
        }
    }

    private void OnDestroy()
    {
        GameObjectsManager.Unregister(gameObject);
    }
}
