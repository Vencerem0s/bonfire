using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public GameObject lightBolt;
    public GameObject golem;

    public Transform shotPoint;
    void Start()
    {
        
    }

    void Update()
    {
        SkillsMage();
    }

    void SkillsMage()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(lightBolt, shotPoint.position, transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            BloodMagic();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(golem, Input.mousePosition, transform.rotation);
        }
    }

    void BloodMagic()
    {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            gameObj.GetComponent<TestEnemy>().MageWantBlood();
        }
    }
}
