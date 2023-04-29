/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
*/
public class lightBoltParametr : LiveParametrs
{

    public override void TakeDamage(string Type, float damage)
    {
        health -= 1;
    }
}
