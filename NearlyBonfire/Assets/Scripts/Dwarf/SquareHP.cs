using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHP : MonoBehaviour
{
    public int _hp;
    void Start()
    {
        _hp = 100;
    }

    public void HPMinus()
    {
        _hp -= 1;
    }
}
