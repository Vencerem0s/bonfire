using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public Transform shotPointDiagonalRight, shotPointDiagonalLeft;
    public float arrowDamage;


    void Start()
    {

    }

    /*void Update()
    {
        
    }*/
    public void Shoot()
    {
        Instantiate(arrow, shotPointDiagonalRight.position, transform.rotation);
        arrowDamage = 20;

    }
}

  
