//Общий класс для объектов способных погибать
/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;

public class LiveParametrs : MonoBehaviour
{
    [SerializeField] public float health, armor, mageResist;
    
    private float _percentArmor, _percentMageResist;
    public float _maxHealth { get; private set; }

    protected virtual void Start()
    {
        GameObjectsManager.Register(gameObject);
        _maxHealth = health;
        _percentArmor = (armor * 0.06f) / (1 + armor * 0.06f);
        _percentMageResist = (mageResist * 0.06f) / (1 + mageResist * 0.06f);
    }

    protected virtual void Update()
    {

    }

    public virtual void TakeDamage(string typeDamage, float damage)
    {
        switch (typeDamage)
        {
            case "physical":
                health -= damage * (1 - _percentArmor);
                break;

            case "magical":
                health -= damage * (1 - _percentMageResist);
                break;
        }
    }

    private void OnDestroy()
    {
        //GameObjectsManager.Unregister(gameObject);
    }
}