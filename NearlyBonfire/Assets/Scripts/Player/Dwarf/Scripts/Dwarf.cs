using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using UnityEditor.SceneManagement;

public class Dwarf : MonoBehaviour
{
    #region CONSTANTS
    private float _speedMoveConst;
    #endregion

    public float _health { get; private set; }
    public float _armor { get; private set; }
    public float _range { get; private set; }
    public Animator _chAnimator { get; private set; }
    private Movement _movement;

    private Dictionary<Type, IPlayerBehaviour> _behaviourMap;
    private IPlayerBehaviour _behaviourCurrent;
    private CancellationTokenSource _cts;

    private void Start()
    {
        InitBehaviors();
        GameObjectsManager.Register(gameObject);
        _health = 100f;
        _range = 0f;
        _armor = 0.9f;

        _chAnimator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _speedMoveConst = _movement.speedMove;
        _cts = new CancellationTokenSource();
        StartPassive();
    }

    private void Update()
    {
        if (CheckUltimate())
        {
            _behaviourCurrent.Update();
            return;
        }

        CheckKeyDown();
    }



    #region PUBLIC METHODS

    public void TakeDamageFromEnemy(float damage, string typeDamage)
    {
        float passiveFactor = 0f;

        if (_behaviourCurrent == GetBehaviour<PassiveBehaviour>())
            passiveFactor = 0.1f;

        if (typeDamage == "magical")
            _health -= damage;
        else
        {
            _health -= damage * _armor;
            _range += passiveFactor * damage;
        }

    }

    public void SetAnimation(string trigger)
    {
        _chAnimator.SetTrigger(trigger);
    }

    public void SetDwarfValues(float range = 0f, float speedMove = 1f, float armor = 0.9f, float axDamage = 20f, float shieldDamage = 2f, float stunTime = 0f)
    {
        _range -= range;
        _movement.speedMove *= speedMove;
        _armor = armor;

        GameObject[] ax = GameObjectsManager.GetGameObjectByTag("Ax");
        ax[0].GetComponent<Ax>().SetAxDamage(axDamage);

        GameObject[] shield = GameObjectsManager.GetGameObjectByTag("Shield");
        shield[0].GetComponent<Shield>().SetShieldValues(shieldDamage, stunTime);
    }

    public void GetRange(float range)
    {
        _range += range;
    }

    public void GetHealth(float health)
    {
        _health += health;
    }

    public void ExitFromUltimate()
    {
        _behaviourCurrent = null;
    }

    public bool CheckUltimate()
    {
        return _behaviourCurrent == GetBehaviour<UltimateBehaviour>();
    }

    #endregion

    #region PRIVATE METHODS

    private void CheckKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetBehaviourStAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Q))// && range >= 20f)
        {
            SetBehaviourFirstSkill();
        }
        else if (Input.GetKeyDown(KeyCode.E))// && range >= 40f)
        {
            SetBehaviourSecondSkill();
        }
        else if (Input.GetKeyDown(KeyCode.F))// && range >= 100f)
        {
            SetBehaviourUltimate();
        }
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

    private async void StartPassive()
    {
        while (_cts.IsCancellationRequested == false)
        {
            var firstState = _behaviourCurrent;
            await Task.Delay(2000);
            var secondState = _behaviourCurrent;

            if (_behaviourCurrent == GetBehaviour<PassiveBehaviour>() || CheckUltimate() == true)
                continue;

            if (firstState == secondState)
                SetBehaviourPassive();
        }
    }

    private void StartMovement()
    {
        _movement.speedMove = _speedMoveConst;
    }

    private void StopMovement()
    {
        _movement.speedMove = 0f;
    }

    private void OnDestroy()
    {
        _cts.Cancel();
    }

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

    #endregion

}
