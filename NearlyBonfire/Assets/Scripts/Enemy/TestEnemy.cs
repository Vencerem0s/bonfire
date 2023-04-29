using System.Collections;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public Transform agro; // Ссылка на Transform agro
    public float speed; // Скорость движения врага

    private GameObject _player;
    private Enemy _enemy;
    private Arrow _arrow;
    private float _stun;
    private Vector3 _direction;
    [SerializeField] private float _damage;




    private void Start()
    {
        _stun = 0f;
        _enemy = GetComponent<Enemy>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        speed = 0f;
        if (_stun > 0f)
        {
            return;
        }
        TakeAgro();
        EnemMovement();
    }

    private void EnemMovement()
    {
        if (agro)
        {
            _direction = agro.position - transform.position;
            _direction.Normalize();
            transform.position += _direction * speed * Time.deltaTime;
        }
        if (agro != _player.transform)
        {
            speed = 2f;
        }
    }

    private void TakeAgro()
    {
        if (GameObject.Find("golem(Clone)"))
        {
            agro = GameObject.Find("golem(Clone)").GetComponent<Transform>();
        }
        else if (GameObject.Find("lightBolt(Clone)"))
        {
            agro = GameObject.Find("lightBolt(Clone)").GetComponent<Transform>();
        }
        else
        {
            agro = _player.transform;
        }
    }

    public void Stun(float secs)
    {
        if (secs <= 0f)
            return;

        _stun = secs;
        StartCoroutine(StunCoroutine());
    }

    private IEnumerator StunCoroutine()
    {
        //запуск анимации стана
        yield return new WaitForSeconds(_stun);
        //запуск анимации ходьбы
        _stun = 0f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("golem") || other.gameObject.CompareTag("lightBolt"))
        {
            //нужно для охотницы
            //_player.GetComponent<Hunter>().takeDamage = true;
            //анимация атаки
            speed = 0f;
        }
        else if (other.gameObject.CompareTag("Boar"))
        {
            Stun(2f);
        }
        else if (other.gameObject.CompareTag("Arrow"))
        {
            _enemy.TakeDamage(_player.GetComponent<Hunter>().DamageCalculation());
        }
        else if (other.gameObject.CompareTag("trippleArrow"))
        {
            _enemy.TakeDamage(_enemy.health);
        }
        else if (other.gameObject.CompareTag("trap"))
        {
            Stun(3f);
            _enemy.TakeDamage(5f);
            _player.GetComponent<Hunter>().concentration += 10f;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("golem") || other.gameObject.CompareTag("lightBolt"))
        {
            //анимация ходьбы
            speed = 2f;
            //нужно для охотницы
            //_player.GetComponent<Hunter>().takeDamage = false;
        }
    }

}
