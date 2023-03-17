using UnityEngine;

public class Dwarf : MonoBehaviour
{
    //public Transform player;

    //private Rigidbody2D rb;

    // private Animator attack;

    void Start()
    {
        //attack = player.GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
        //attack.SetBool("Attack", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("Q key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            print("E key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            print("F key was pressed");
        }
    }

    //анимация работает, но дайдём до нее после
    /*private void OnMouseDrag()
    {
        Debug.Log("atach");
        attack.SetBool("Attack", true);
    }

    private void OnMouseUp()
    {
        Debug.Log("noatach");
        attack.SetBool("Attack", false);
    }*/
}
