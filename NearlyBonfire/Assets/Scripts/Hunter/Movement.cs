using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public Vector2 moveVector;
    public float speed;
    private GameObject player;
    private Transform saxeTrans;
    private Hunter _hunter;

    void Start()
    {
        saxeTrans = gameObject.transform;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Walk();
        LookAtMouse();
    }

    private void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveVector.x * speed, moveVector.y * speed);
       
    }

    private void LookAtMouse()
    {
        
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(saxeTrans.position); // ���������� ������� ��� ������� ��������, � � ����������� � �������� ����. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // ���������� �������� ���� � ������� ��� � �������.
        saxeTrans.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // �������� ������� �� ���������� �������� ��������.
    }

   

    
}
