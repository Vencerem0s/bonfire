using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventManger
{

    public static Action<string> onPlayerThingAgro; //������������ ���� � �������� � ����� �� ������ ��� �������� �� ����������
    
    public static Action<int> Stuned;

    public static Action<string, float> BloodDamage; //��������� ����� ����� �� ���������� �����

    public static Action<float> BloodHeal; //�������� ���������� �������� ���� �� ���������� �����

    public static Action<float> TakeAttribute;

}
