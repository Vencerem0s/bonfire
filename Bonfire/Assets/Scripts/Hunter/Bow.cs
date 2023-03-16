using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float arrowSpeed;
    public Transform shotPoint;
    private float timeBtwShots;
    private float startTimeBtwShots = 0.25f;
    void Start()
    {
        
    }

    void Update()
    {
        if(timeBtwShots <= 0)
        {
            LookAtMouseKlick();
            timeBtwShots = startTimeBtwShots;
        }else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
        
    }

    private void LookAtMouseKlick()
    {
        if (Input.GetMouseButton(0))
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, transform.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.forward * arrowSpeed;
    }
}
