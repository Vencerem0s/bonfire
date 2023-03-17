using UnityEngine;

public class Staff : MonoBehaviour
{
    private Collider2D coll;

    void Start()
    {
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
    }

    /*void Update()
    {
        
    }*/

    public void StaffSpell()
    {
        coll.enabled = true;
    }

    public void StaffSpellOff()
    {
        coll.enabled = false;
    }
}
