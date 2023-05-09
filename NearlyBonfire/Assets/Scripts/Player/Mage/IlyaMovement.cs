using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using static Cinemachine.AxisState;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

public class IlyaMovement : MonoBehaviour
{
    public Vector3 moveVector;
    public float speedMove, movesum;
    private float speedconst, time;
    private Transform _saxeTrans;
    private CharacterController _chController;
    private List<Task> _awaitList;
    private Task Tasks;


    private void Start()
    {
        _awaitList = new List<Task>();
        speedconst = speedMove;
        time = 0f;
        _chController = GetComponent<CharacterController>();
        _saxeTrans = gameObject.transform;
    }


    private void Update()
    {
        if (time <= 0f)
        {
            CharacterMove(moveVector);
        }
        LookAtMouse();
    }

    private void CharacterMove(Vector3 moveVector)
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");

        movesum = moveVector.x + moveVector.z;

        _chController.Move(moveVector * speedMove * Time.deltaTime);

        /*if(time == 0f)// && movesum == 0f)
        {
            speedMove = speedconst;
        }*/
        /*else
        {
            speedMove = speedconst;
        }*/
    }

    private void LookAtMouse()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(_saxeTrans.position); // Нахождение катетов для расчёта тангенса, а в последствии и градусов угла. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Нахождение тангенса угла и перевод его в градусы.
        _saxeTrans.rotation = Quaternion.AngleAxis(-1 * (angle - 90), Vector3.up); // Вращение объекта на полученное значение градусов.
    }

    public async void SpellDuration(float duration)
    {
        time = duration;
        //StartCoroutine(SpellDurCour());
        _awaitList.Add(SpellDurCour(duration));
        //await SpellDurCour(duration);
        Tasks = Task.WhenAll(_awaitList);
        try
        {
            await Tasks;
        }
        catch { }
        if (Tasks.Status == TaskStatus.RanToCompletion)
        {
            time = 0f;
            speedMove = speedconst;
        }
    }

    //IEnumerator SpellDurCour()
    async Task SpellDurCour(float duration)
    {
        speedMove = 0f;
        await Task.Delay((int)duration * 1000); //Task.WhenAll(SpellDurCour);//yield return new WaitForSeconds(time);
        /*time = 0f;
        speedMove = speedconst;*/
        //print("endinside");
    }
}
