//Общий класс для объектов способных погибать
/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;

public class LiveParametrs : MonoBehaviour
{
    [SerializeField] public float health, armor, mageResist;
<<<<<<< HEAD
    
    private float _percentArmor, _percentMageResist;
    public float _maxHealth { get; private set; }
=======
    protected private float _maxHealth, _percentArmor, _percentMageResist;
>>>>>>> 5f8df113d27612bc60df048909a0ee7b6e355b35

    protected virtual void Start()
    {
        GameObjectsManager.Register(gameObject);
        _maxHealth = health;
<<<<<<< HEAD
        _percentArmor = (armor * 0.06f) / (1 + armor * 0.06f);
        _percentMageResist = (mageResist * 0.06f) / (1 + mageResist * 0.06f);
=======
        _percentArmor = 100 * (armor * 0.06f) / (1 + armor * 0.06f);
        _percentMageResist = 100 * (mageResist * 0.06f) / (1 + mageResist * 0.06f);
>>>>>>> 5f8df113d27612bc60df048909a0ee7b6e355b35
    }

    protected virtual void Update()
    {

    }

    public virtual void TakeDamage(string typeDamage, float damage)
    {
        switch (typeDamage)
        {
            case "physical":
<<<<<<< HEAD
                health -= damage * (1 - _percentArmor);
                break;

            case "magical":
                health -= damage * (1 - _percentMageResist);
=======
                health -= (damage - damage * _percentArmor / 100);
                break;

            case "magical":
                health -= (damage - damage * _percentMageResist / 100);
>>>>>>> 5f8df113d27612bc60df048909a0ee7b6e355b35
                break;
        }
    }

    private void OnDestroy()
    {
        //GameObjectsManager.Unregister(gameObject);
    }
}