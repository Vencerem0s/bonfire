using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterSkills : MonoBehaviour
{
    public float concentration;
    public Transform boarSpawnPositionLeftUp, boarSpawnPositionLeftDown, boarSpawnPositionRight;
    public GameObject boar;
    private Hunter _hunter;
    private Enemy enemy;
    private Movement _movement;

    private Bow bow;


    void Start()
    {
        bow = GameObject.Find("Bow").GetComponent<Bow>();
        _hunter = GetComponent<Hunter>();
        concentration = 0f;
        //StartCoroutine(AccumulationOfConcentration());
    }

    //public IEnumerator DelayTime()
    //{
    //    yield return new WaitForSeconds(2f);
    //}

    IEnumerator AccumulationOfConcentration()
    {
        //while (_hunter.takeDamage == false && (_movement.moveVector.x != 0 || _movement.moveVector.y != 0))
        //{
        //    yield return new WaitForSeconds(1f);
        //    concentration++;

        //    if (concentration >= 100)
        //        break;
        //}

        Vector2 magePos1 = GetComponent<Transform>().position;
        yield return new WaitForSeconds(2f);
        Vector2 magePos2 = GetComponent<Transform>().position;
        if ((magePos1 != magePos2) && _hunter.takeDamage == false)
        {
            if (concentration >= 100)
            {
                concentration = 100f;
            }
            concentration += 0.005f;
        }

    }

    public void StartAccumulationOfConcentration()
    {
        StartCoroutine(AccumulationOfConcentration());
    }

    IEnumerator SpawnBoarPosition()
    {
        Instantiate(boar, boarSpawnPositionLeftUp.position, boarSpawnPositionLeftDown.rotation);
        yield return new WaitForSeconds(2f);
        Instantiate(boar, boarSpawnPositionRight.position, boarSpawnPositionRight.rotation);
        yield return new WaitForSeconds(2f);
        Instantiate(boar, boarSpawnPositionLeftDown.position, boarSpawnPositionLeftDown.rotation);
    }

    public void SpawnBoar()
    {
        StartCoroutine(SpawnBoarPosition());
        concentration -= 20f;
    }

    public void TrippleShoot()
    {
        Instantiate(bow.arrow, bow.shotPointDiagonalRight.position, bow.transform.rotation);
        Instantiate(bow.arrow, bow.shotPointDiagonalRight.position, bow.shotPointDiagonalLeft.rotation);
        Instantiate(bow.arrow, bow.shotPointDiagonalRight.position, bow.shotPointDiagonalRight.rotation);
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        bow.arrowDamage = enemy.health;
        concentration -= 20f;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(AccumulationOfConcentration());
    }
}
