using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public int health;
    public bool takeDamage;
    private HunterSkills hunterSkills;

    void Start()
    {
        takeDamage = false;
        hunterSkills = GetComponent<HunterSkills>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hunterSkills.TrippleShoot();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            hunterSkills.SpawnBoar();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            print("F key was pressed");
        }
    }

    
}
