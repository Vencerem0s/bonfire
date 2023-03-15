using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Dwarf : MonoBehaviour
{
    public Transform player;
    private Animator attack;
    void Start()
    {
        attack = player.GetComponent<Animator>();
        attack.SetBool("Attack", false);
    }

    private void OnMouseDown()
    {
        Debug.Log("atach");
        attack.SetBool("Attack", true);
    }

    private void OnMouseUp()
    {
        Debug.Log("noatach");
        attack.SetBool("Attack", false);
    }
}
