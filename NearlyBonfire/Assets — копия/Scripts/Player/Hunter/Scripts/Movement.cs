using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 _moveVector { get; private set; }
    public float speedMove;
    private Transform _saxeTrans;
    private CharacterController _chController;
    private Animator _chAnimator;



    private void Start()
    {
        _moveVector = Vector3.zero;
        _chAnimator = GetComponent<Animator>();
        _chController = GetComponent<CharacterController>();
        _saxeTrans = gameObject.transform;
    }


    private void Update()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(_saxeTrans.position); // Нахождение катетов для расчёта тангенса, а в последствии и градусов угла. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Нахождение тангенса угла и перевод его в градусы.
        _saxeTrans.rotation = Quaternion.AngleAxis(-1 * (angle - 90), Vector3.up); // Вращение объекта на полученное значение градусов.
        CharacterMove(_moveVector, LookAtAngle(angle));
    }

    private void CharacterMove(Vector3 _moveVector, string direction)
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.z = Input.GetAxis("Vertical");


        switch (direction)
        {
            case "Forward":
                _chAnimator.SetFloat("x", _moveVector.x);
                _chAnimator.SetFloat("y", _moveVector.z);
                break;
            case "left":
                _chAnimator.SetFloat("x", _moveVector.z * -1f);
                _chAnimator.SetFloat("y", _moveVector.x * -1f);
                break;
            case "Back":
                _chAnimator.SetFloat("x", _moveVector.x * -1f);
                _chAnimator.SetFloat("y", _moveVector.z * -1f);
                break;
            case "right":
                _chAnimator.SetFloat("x", _moveVector.z);
                _chAnimator.SetFloat("y", _moveVector.x);
                break;
            default:
                print("Error direction");
                break;
        }

        _chController.Move(_moveVector * speedMove * Time.deltaTime);
    }

    private string LookAtAngle(float angle)
    {
        if (angle >= 45 && angle <= 135)
        {
            return "Forward";
        }
        else if (angle > 135 || angle < -135)
        {
            return "left";
        }
        else if (angle >= -135 && angle <= -45)
        {
            return "Back";
        }
        else if (angle < 45 && angle > -45)
        {
            return "right";
        }

        return "Error angle";
    }

}
