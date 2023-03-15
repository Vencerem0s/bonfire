/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;

//скрипт позволяет следить за нахождением курсора мыши, для нанесения удара в нужном направлении.

public class SaxeArea : MonoBehaviour
{
    private Transform saxeTrans;

    void Start()
    {
        saxeTrans = gameObject.transform;
    }

    void Update()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(saxeTrans.position); // Нахождение катетов для расчёта тангенса, а в последствии и градусов угла. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Нахождение тангенса угла и перевод его в градусы.
        saxeTrans.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Вращение объекта на полученное значение градусов.
    }
}
