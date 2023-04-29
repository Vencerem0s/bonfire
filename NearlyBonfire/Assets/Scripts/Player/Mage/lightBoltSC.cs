/*using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;*/
using UnityEngine;
using System.Threading.Tasks;
//using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class lightBoltSC : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    public GameObject explosionAnim;

    private LiveParametrs _parametr;
    private bool _destroy;

    void Start()
    {
        _destroy = true;
        GameObjectsManager.Register(gameObject);
        _parametr = GetComponent<LiveParametrs>();

        AgroOnMe();
    }
        
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z > 56f)
        {
            Destroy(gameObject);
        }

        if (_parametr.health <= 0)
        {
            Instantiate(explosionAnim, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private async void AgroOnMe()
    {
        while (_destroy)
        {
            if (GameObjectsManager.GetGameObjectByTag("golem").Length <= 0)
            {
                GameEventManger.onPlayerThingAgro?.Invoke(gameObject.tag);
            }
            await Task.Delay(1000);
        }
    }

    private void OnDestroy()
    {
        _destroy = false;
        GameObjectsManager.Unregister(gameObject);
        if (GameObjectsManager.GetGameObjectByTag("golem").Length <= 0)
        {
            GameEventManger.onPlayerThingAgro?.Invoke("Player");
        }
    }
}
