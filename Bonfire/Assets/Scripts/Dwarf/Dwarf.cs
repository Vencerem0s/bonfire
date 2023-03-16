using UnityEngine;

public class Dwarf : MonoBehaviour
{
    public Transform player;
    public Vector2 moveVector;

    private Rigidbody2D rb;

    [SerializeField] private float speed;

    private Animator attack;

    void Start()
    {
        speed = 1f;
        attack = player.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        attack.SetBool("Attack", false);
    }

    private void Update()
    {
        Walk();
    }

    private void OnMouseDrag()
    {
        Debug.Log("atach");
        attack.SetBool("Attack", true);
    }

    private void OnMouseUp()
    {
        Debug.Log("noatach");
        attack.SetBool("Attack", false);
    }

    private void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveVector.x * speed, moveVector.y * speed);
    }
}
