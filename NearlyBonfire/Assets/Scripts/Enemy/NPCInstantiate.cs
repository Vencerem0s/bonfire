//скрипт, который определ€ет когда NPC по€вл€етс€
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInstantiate : MonoBehaviour
{
    [SerializeField] private bool isEscortNPC = false;
    
    void Start()
    {
        
    }
        
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if(isEscortNPC)
        {
            GameEventManger.SummonEscort?.Invoke(name);
        }
    }
}
