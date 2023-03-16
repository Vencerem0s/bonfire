using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private GameObject weapon;
    private Bow bow;

    private void Start()
    {
        if(GameObject.Find("Dwarf"))
        {
            Debug.Log("������� ��� ����� �����");
        }
        else if(GameObject.Find("Mage"))
        {
            Debug.Log("������� ��� ����� ����");
        }
        else if(GameObject.Find("Hunter"))
        {
            weapon = GameObject.Find("Bow");
            bow = weapon.GetComponent<Bow>();
        }
        else
        {
            Start();
        }
    }

    private void OnMouseDown()
    {
        bow.Shoot();
    }
}
