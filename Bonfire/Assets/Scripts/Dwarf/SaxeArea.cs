/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;

//������ ��������� ������� �� ����������� ������� ����, ��� ��������� ����� � ������ �����������.

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
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(saxeTrans.position); // ���������� ������� ��� ������� ��������, � � ����������� � �������� ����. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // ���������� �������� ���� � ������� ��� � �������.
        saxeTrans.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // �������� ������� �� ���������� �������� ��������.
    }
}
