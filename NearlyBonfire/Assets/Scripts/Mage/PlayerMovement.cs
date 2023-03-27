using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementspeed;
    //public static float vertical, horizontal;

    Rigidbody Rigidbodyrb;
    //Vector3 pointingTarget;

    void Start()
    {
        Rigidbodyrb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        LookAtMouse();
    }

    void Move()
    {
        Vector3 mov = new Vector3(Input.GetAxis("Horizontal") * movementspeed, 0f, Input.GetAxis("Vertical") * movementspeed);
        mov = Vector3.ClampMagnitude(mov, movementspeed);

        if (mov != Vector3.zero)
        {
            Rigidbodyrb.MovePosition(transform.position + mov * Time.deltaTime);
            Rigidbodyrb.MoveRotation(Quaternion.LookRotation(mov));
        }
    }

    void LookAtMouse()
    {
        /*var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position); // Нахождение катетов для расчёта тангенса, а в последствии и градусов угла. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Нахождение тангенса угла и перевод его в градусы.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.down);*/ // Вращение объекта на полученное значение градусов.
        
        
        RaycastHit hit;
        Ray mouseray = new Ray(transform.position, Camera.main.WorldToScreenPoint(Input.mousePosition) - transform.position);

        if (hit.rigidbody != null)
        {
            transform.LookAt(hit.transform.position);
        }
    }
}
