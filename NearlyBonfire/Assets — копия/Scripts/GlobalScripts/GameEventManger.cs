using UnityEngine;
using System;
using Unity.VisualScripting;

public class GameEventManger
{

    public static Action<string> onPlayerThingAgro; //отрабатывает агро в движении в энеми на игрока или агроботы им вызываемые
    
    public static Action<int> Stuned;

    public static Action<string, float> BloodDamage; //нанесение урона энеми от заклинания крови

    public static Action<float> BloodHeal; //передаем количество здоровья магу за заклинание крови

    public static Action<float> TakeAttribute;

}
