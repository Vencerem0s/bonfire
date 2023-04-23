using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using System.IO;

public class Dwarf : MonoBehaviour
{
    public float _health { get; private set; }
    public float _armor { get; private set; }
    public float _range { get; private set; }
    public float _axDamage { get; private set; }
    private bool _ultimate;
    private Animator _chAnimator;
    private Movement _movement;

    private Dictionary<Type, IPlayerBehaviour> _behaviourMap;
    private IPlayerBehaviour _behaviourCurrent;

    private void Start()
    {
        InitBehaviors();
        _range = 0f;
        _armor = 0.9f;
        _axDamage = 20f;
        _ultimate = false;

        _chAnimator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        StartCoroutine(StartPassiveRoutine());
    }

    private void Update()
    {
        if(_behaviourCurrent != GetBehaviour<UltimateBehaviour>())
            CheckKeyDown();
    }

    private void InitBehaviors()
    {
        _behaviourMap = new Dictionary<Type, IPlayerBehaviour>();

        _behaviourMap[typeof(StAttackBehaviour)] = new StAttackBehaviour(this);
        _behaviourMap[typeof(FirstSkillBehaviour)] = new FirstSkillBehaviour(this);
        _behaviourMap[typeof(SecondSkillBehaviour)] = new SecondSkillBehaviour(this);
        _behaviourMap[typeof(UltimateBehaviour)] = new UltimateBehaviour(this);
        _behaviourMap[typeof(PassiveBehaviour)] = new PassiveBehaviour(this);
    }

    private void SetBehaviour(IPlayerBehaviour newBehaviour)
    {
        if (_behaviourCurrent != null)
            _behaviourCurrent.Exit();

        _behaviourCurrent = newBehaviour;
        _behaviourCurrent.Enter();
    }

    private IPlayerBehaviour GetBehaviour<T>() where T : IPlayerBehaviour
    {
        var type = typeof(T);
        return _behaviourMap[type];
    }

    private void CheckKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetBehaviourStAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && _ultimate == false)// && range >= 20f)
        {
            SetBehaviourFirstSkill();
        }
        else if (Input.GetKeyDown(KeyCode.E) && _ultimate == false)// && range >= 40f)
        {
            SetBehaviourSecondSkill();
        }
        else if (Input.GetKeyDown(KeyCode.F) && _ultimate == false)// && range >= 100f)
        {
            SetBehaviourUltimate();
        }
    }

    

    public void TakeDamageFromEnemy(float damage, string typeDamage)
    {
        if (typeDamage == "magical")
            _health -= damage;
        else
            _health -= damage * _armor;
    }

    public void SetAnimation(string trigger)
    {
        _chAnimator.SetTrigger(trigger);
    }

    public void SetUltimate(bool ultimate)
    {
        _ultimate = ultimate;
    }

    public void SetDwarfValues(float speedMove , float armor)
    {
        _movement.speedMove *= speedMove;
        _armor = armor;
    }

    public void SetDwarfValues(float speedMove, float range, float axDamage, float health)
    {
        _movement.speedMove *= speedMove;
        _range -= range;
        _axDamage += axDamage;
        _health += health;
    }

    private IEnumerator StartPassiveRoutine()
    {
        while (true)
        {
            var firstState = _behaviourCurrent;
            yield return new WaitForSeconds(2f);
            var secondState = _behaviourCurrent;

            if (firstState == secondState)
                SetBehaviourPassive();
        }
        
    }

    //public void DoExitBehaviour()
    //{
    //    _behaviourCurrent = null;
    //}

    private void SetBehaviourStAttack()
    {
        var behaviour = GetBehaviour<StAttackBehaviour>();
        SetBehaviour(behaviour);
    }

    private void SetBehaviourFirstSkill()
    {
        var behaviour = GetBehaviour<FirstSkillBehaviour>();
        SetBehaviour(behaviour);
    }

    private void SetBehaviourSecondSkill()
    {
        var behaviour = GetBehaviour<SecondSkillBehaviour>();
        SetBehaviour(behaviour);
    }

    private void SetBehaviourUltimate()
    {
        var behaviour = GetBehaviour<UltimateBehaviour>();
        SetBehaviour(behaviour);
    }

    private void SetBehaviourPassive()
    {
        var behaviour = GetBehaviour<PassiveBehaviour>();
        SetBehaviour(behaviour);
    }
}
