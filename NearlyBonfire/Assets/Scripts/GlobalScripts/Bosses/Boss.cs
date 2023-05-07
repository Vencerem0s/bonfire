using BossChaosGoblin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int _phaseNumber { get; private set; }
    public Animator _bossAnimator { get; private set; }

    private float _randomSkill;

    private BossBehaviour _behaviourCurrent;
    private IInitBossBehaviour _initBossBehaviour;

    private EnemyMovement _enemyMovement;
    private BossParametrs _bossParametrs;


    private void Awake()
    {
        InitBoss();
        _enemyMovement = GetComponent<EnemyMovement>();
        _bossAnimator = GetComponent<Animator>();
        _bossParametrs = GetComponent<BossParametrs>();
        _randomSkill = 0f;
        _phaseNumber = 1;
    }

    private void Start()
    {
        _initBossBehaviour.InitBehaviours(this);
        GameObjectsManager.Register(gameObject);
        _bossParametrs.bossTakeDamageEvent += BossTakeDamage;
        _bossParametrs.changeBossPhaseEvent += ChangePhase;

        SetPhaseAnim(_phaseNumber);
        _enemyMovement.TakeAgro("Player");
        StartCoroutine(asdas());
    }

    public IEnumerator asdas()
    {
        yield return new WaitForSeconds(2f);
        SetBehaviour(_initBossBehaviour.SetPhaseChange());
    }

    private void Update()
    {
        _behaviourCurrent?.Update();
    }

    private void OnDestroy()
    {
        _bossParametrs.bossTakeDamageEvent -= BossTakeDamage;
        Destroy(gameObject);
    }

    #region PUBLIC METHODS
    public void SetAnimation(string trigger)
    {
        _bossAnimator.SetTrigger(trigger);
    }

    public void ChangePhaseNumber()
    {
        _phaseNumber = 2;
    }

    public void SetPhaseAnim(int phaseNumber)
    {
        _bossAnimator.SetInteger("Phase", phaseNumber);
    }

    public void GetOutOfState()
    {
        _behaviourCurrent = null;
    }
    #endregion

    #region PRIVATE METHODS
    private void InitBoss()
    {
        switch (gameObject.name)
        {
            case "BossChaosGoblin":
                _initBossBehaviour = new BossChaosGoblin.StateSwitch();
                break;
        }
    }

    private void BossTakeDamage(float oldHealthValue, float newHealthValue)
    {
        if (_behaviourCurrent != null) // удалить после того как сделаю что боссы при включении состо€ни€ станов€тс€ неу€звимыми
            return;

        if ((newHealthValue / oldHealthValue) < 0.05f)
            return;

        if (_randomSkill >= 100f)
            _randomSkill = 0f;

        float rValue = UnityEngine.Random.Range(0, 100);
        _randomSkill += rValue;

        if (_phaseNumber >= 2)
            SetSkillsSecondPhase();
        else
            SetSkillsFirstPhase();
    }

    private void SetSkillsFirstPhase()
    {
        if (_randomSkill >= 75f)
        {
            SetBehaviour(_initBossBehaviour.SetSecondSkillFirstPhase());
            return;
        }

        if (_randomSkill >= 50f)
            SetBehaviour(_initBossBehaviour.SetFirstSkillFirstPhase());
    }

    private void SetSkillsSecondPhase()
    {
        if (_randomSkill >= 75f)
        {
            SetBehaviour(_initBossBehaviour.SetSecondSkillSecondPhase());
            return;
        }

        if (_randomSkill >= 50f)
            SetBehaviour(_initBossBehaviour.SetFirstSkillSecondPhase());
    }

    private void ChangePhase(float newHealthValue)
    {
        if (_phaseNumber >= 2)
        {
            _bossParametrs.changeBossPhaseEvent -= ChangePhase;
            return;
        }

        if ((newHealthValue / _bossParametrs._maxHealth) > 0.5f)
            return;

        SetBehaviour(_initBossBehaviour.SetPhaseChange());
    }

    private void SetBehaviour(BossBehaviour newBehaviour)
    {
        if (_behaviourCurrent != null)
            _behaviourCurrent.Exit();

        _behaviourCurrent = newBehaviour;
        _behaviourCurrent.Enter();
    }
    #endregion
}
