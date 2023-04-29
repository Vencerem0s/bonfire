//Общий класс для объектов способных погибать
/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;

public class LiveParametrs : MonoBehaviour
{
    public float health, maxHealth, armor, mageResist;

    protected virtual void Start()
    {
        GameObjectsManager.Register(gameObject);
        maxHealth = health;
    }

    protected virtual void Update()
    {

    }

    public virtual void TakeDamage(string typeDamage,float damage)
    {
        switch (typeDamage)
        {
            case "physical":
                health -= damage - (damage * armor / 100);
                break;

            case "magical":
                health -= damage - (damage * mageResist / 100);
                break;
        }
    }

    private void OnDestroy()
    {
        //GameObjectsManager.Unregister(gameObject);
    }
}
