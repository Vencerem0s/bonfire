using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public float health;
    public bool takeDamage;
    public Transform shotPointDiagonalRight, shotPointDiagonalLeft;
    public Transform boarSpawnPositionLeftUp, boarSpawnPositionLeftDown, boarSpawnPositionRight;
    public GameObject boar;
    public GameObject arrow, trippleArrow;
    public GameObject trap;

    public float concentration;
    private float _criticalDamage;
    public float _arrowDamage { get; private set; }
    public float _trapTime { get; private set; }
    public bool _ultimate { get; private set; }
    private Transform _hunterPos;
    private Animator _chAnimator;
    private Movement _movement;

    private void Start()
    {
        takeDamage = false;
        _ultimate = false;
        concentration = 0f;
        _trapTime = 5f;
        _arrowDamage = 20f;
        _hunterPos = GetComponent<Transform>();
        _chAnimator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        StartCoroutine(AccumulationOfConcentration());
        StartCoroutine(StandTrap());
    }

    private void Update()
    {
        CheckKeyDown();
    }

    private void CheckKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _chAnimator.SetTrigger("StAttack");
        }
        else if (Input.GetKeyDown(KeyCode.Q) && concentration >= 20f && _ultimate == false)
        {
            concentration -= 20f;
            _chAnimator.SetTrigger("TripleShoot");
        }
        else if (Input.GetKeyDown(KeyCode.E) && concentration >= 40f && _ultimate == false)
        {
            concentration -= 20f;
            SpawnBoar();
        }
        else if (Input.GetKeyDown(KeyCode.F) && concentration == 100f && _ultimate == false)
        {
            StartUltimate();
        }
    }

    private IEnumerator AccumulationOfConcentration()
    {
        while (true)
        {
            if (_ultimate == false)
            {
                Vector2 hunterPos1 = new Vector2((float)System.Math.Round(_hunterPos.position.x, 1), (float)System.Math.Round(_hunterPos.position.z, 1));
                yield return new WaitForSeconds(0.2f);
                Vector2 hunterPos2 = new Vector2((float)System.Math.Round(_hunterPos.position.x, 1), (float)System.Math.Round(_hunterPos.position.z, 1));
                if ((hunterPos1 != hunterPos2) && takeDamage == false)
                {
                    if (concentration >= 100f) concentration = 100f;
                    else
                    {
                        yield return new WaitForSeconds(1f);
                        concentration += 1f;
                    }

                }
            }
        }
    }

    private IEnumerator StandTrap()
    {
        while (true)
        {
            if (_ultimate == false)
            {
                Vector2 hunterPos1 = new Vector2((float)System.Math.Round(_hunterPos.position.x, 1), (float)System.Math.Round(_hunterPos.position.z, 1));
                yield return new WaitForSeconds(0.2f);
                Vector2 hunterPos2 = new Vector2((float)System.Math.Round(_hunterPos.position.x, 1), (float)System.Math.Round(_hunterPos.position.z, 1));
                if (hunterPos1 != hunterPos2)
                {
                    if (_trapTime <= 0)
                    {
                        Instantiate(trap, transform.position, transform.rotation);
                        _trapTime = 5f;
                        yield return new WaitForSeconds(1f);
                    }
                    else
                    {
                        yield return new WaitForSeconds(1f);
                        _trapTime--;
                    }
                }
            }
        }
    }

    private void Shoot()
    {
        Instantiate(arrow, shotPointDiagonalRight.position, transform.rotation);
    }

    private void TripleShoot()
    {
        Instantiate(trippleArrow, shotPointDiagonalRight.position, transform.rotation);
        Instantiate(trippleArrow, shotPointDiagonalRight.position, shotPointDiagonalLeft.rotation);
        Instantiate(trippleArrow, shotPointDiagonalRight.position, shotPointDiagonalRight.rotation);
    }

    private void SpawnBoar()
    {
        StartCoroutine(SpawnBoarPosition());
    }

    private IEnumerator SpawnBoarPosition()
    {
        Instantiate(boar, boarSpawnPositionLeftUp.position, boarSpawnPositionLeftDown.rotation);
        yield return new WaitForSeconds(2f);
        Instantiate(boar, boarSpawnPositionRight.position, boarSpawnPositionRight.rotation);
        yield return new WaitForSeconds(2f);
        Instantiate(boar, boarSpawnPositionLeftDown.position, boarSpawnPositionLeftDown.rotation);
    }

    private void StartUltimate()
    {
        concentration -= 100f;
        _ultimate = true;
        StartCoroutine(Ultimate());
    }

    private IEnumerator Ultimate()
    {
        _movement.speedMove *= 2f;
        _arrowDamage *= 2f;
        yield return new WaitForSeconds(10f);
        _movement.speedMove /= 2f;
        _arrowDamage /= 2f;
        _ultimate = false;
    }

    public float DamageCalculation()
    {
        if(_ultimate == false)
        {
            _criticalDamage = Random.value;
            if (_criticalDamage <= 0.1f)
                health += 10f;
                return (_arrowDamage * 1.5f);
        }
        
        return _arrowDamage;
    }
}
