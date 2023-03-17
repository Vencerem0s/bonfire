using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float arrowSpeed;
    public Transform shotPoint;
    //private float timeBtwShots;
    //private float startTimeBtwShots = 2f;

    /*void Start()
    {
        
    }*/

    /*void Update()
    {
        if(timeBtwShots <= 0)
        {
            LookAtMouseKlick();
            timeBtwShots = startTimeBtwShots;
        }else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
        
    }*/
    public void Shoot()
    {
        Instantiate(arrow, shotPoint.position, transform.rotation);
    }


    /*private void LookAtMouseKlick()
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
    }*/
}
