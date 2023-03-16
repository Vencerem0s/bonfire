using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 2f;
    

    private Transform saxeTrans;
    public GameObject hunter;

    void Start()
    {
        saxeTrans = gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        HunterWalk();
        LookAtMouse();
        
    }

    private void HunterWalk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveVector.x * speed, moveVector.y * speed);
    }

    private void LookAtMouse()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(saxeTrans.position); // Нахождение катетов для расчёта тангенса, а в последствии и градусов угла. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Нахождение тангенса угла и перевод его в градусы.
        saxeTrans.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Вращение объекта на полученное значение градусов.
    }

   

    //void OnMouseDown()
    //{
    //    Debug.Log("piu piu");
    //}

    //void OnMouseUp()
    //{
    //    Debug.Log("noatach");
    //}
}
