using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using static Cinemachine.AxisState;

public class IlyaMovement : MonoBehaviour
{
    public Vector3 moveVector;
    public float speedMove, movesum;
    private float speedconst, time;
    private Transform _saxeTrans;
    private CharacterController _chController;
    

    private void Start()
    {
        speedconst = speedMove;
        time = 0f;
        _chController = GetComponent<CharacterController>();
        _saxeTrans = gameObject.transform;
    }


    private void Update()
    {
        CharacterMove(moveVector);
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

    public void SpellDuration(float duration)
    {
        time = duration;
        StartCoroutine(SpellDurCour());
    }

    IEnumerator SpellDurCour()
    {
        speedMove = 0f;
        yield return new WaitForSeconds(time);
        time = 0f;
        speedMove = speedconst;
    }
}
