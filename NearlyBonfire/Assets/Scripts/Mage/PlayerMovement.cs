using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Vector3 moveVector;
    //public static float vertical, horizontal;

    Rigidbody rb;
    //Vector3 pointingTarget;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Move();
        //LookAtMouse();
        //Move();
        LookAtMouse();
    }

    void Move()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector * movementSpeed * Time.deltaTime);

        //Vector3 mov = new Vector3(Input.GetAxis("Horizontal") * movementspeed, 0f, Input.GetAxis("Vertical") * movementspeed);
        //mov = Vector3.ClampMagnitude(mov, movementspeed);

        //if (mov != Vector3.zero)
        //{
        //    rb.MovePosition(transform.position + mov * Time.deltaTime);
        //    rb.MoveRotation(Quaternion.LookRotation(mov));
        //}
    }

    void LookAtMouse()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position); // Нахождение катетов для расчёта тангенса, а в последствии и градусов угла. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Нахождение тангенса угла и перевод его в градусы.
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.down); // Вращение объекта на полученное значение градусов.


        //RaycastHit hit;
        //Ray mouseray = new Ray(transform.position, Camera.main.WorldToScreenPoint(Input.mousePosition) - transform.position);

        //if (hit.rigidbody != null)
        //{
        //    transform.LookAt(hit.transform.position);
        //}
    }
}
