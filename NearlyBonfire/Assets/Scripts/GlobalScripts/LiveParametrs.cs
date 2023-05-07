//Общий класс для объектов способных погибать
/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;

public class LiveParametrs : MonoBehaviour
{
    [SerializeField] public float health, armor, mageResist;
    protected private float _maxHealth, _percentArmor, _percentMageResist;

    protected virtual void Start()
    {
        GameObjectsManager.Register(gameObject);
        _maxHealth = health;
        _percentArmor = 100 * (armor * 0.06f) / (1 + armor * 0.06f);
        _percentMageResist = 100 * (mageResist * 0.06f) / (1 + mageResist * 0.06f);
    }

    protected virtual void Update()
    {

    }

    public virtual void TakeDamage(string typeDamage,float damage)
    {
        switch (typeDamage)
        {
            case "physical":
                health -= (damage - damage * _percentArmor / 100);
                break;

            case "magical":
                health -= (damage - damage * _percentMageResist / 100);
                break;
        }
    }

    private void OnDestroy()
    {
        //GameObjectsManager.Unregister(gameObject);
    }
}
