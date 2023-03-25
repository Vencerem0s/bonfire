using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBoltSC : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    void Start()
    {
        
    }
        
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
