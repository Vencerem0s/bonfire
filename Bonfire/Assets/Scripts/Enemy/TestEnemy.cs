using System.Collections;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public Transform agro; // ������ �� Transform agro
    private GameObject player;
    //public float speed = 2f; // �������� �������� �����
    private Enemy enemy;
    private Bow bow;
    public float speed; // �������� �������� �����
    
    private float stun;


    private Vector3 direction;

    [SerializeField] private float damage;

    private void Start()
    {
        bow = GameObject.Find("Bow").GetComponent<Bow>();
        enemy = GetComponent<Enemy>();
        stun = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (stun > 0f)
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
            direction = agro.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
        if (agro != player.transform)
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
            agro = player.transform;
        }
    }

    IEnumerator Stun()
    {
        speed = 0f;
        enemy.TakeDamage(50);
        yield return new WaitForSeconds(2f);
        speed = 2f;
    }

    public void Stun(float secs)
    {
        stun = secs;
        StartCoroutine(StunCoroutine());
    }

    IEnumerator StunCoroutine()
    {
        //������ �������� �����
        yield return new WaitForSeconds(stun);
        //������ �������� ������
        stun = 0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("golem") || other.gameObject.CompareTag("lightBolt"))
        {
            player.GetComponent<Hunter>().takeDamage = true;
            //StartCoroutine(player.GetComponent<HunterSkills>().DelayTime());
            //�������� �����
            speed = 0f;
        }else if (other.gameObject.CompareTag("Boar"))
        {
            StartCoroutine(Stun());
        }else if (other.gameObject.CompareTag("Arrow"))
        {
            enemy.TakeDamage(bow.arrowDamage);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("golem") || other.gameObject.CompareTag("lightBolt"))
        {
            //�������� ������
            speed = 2f;
            player.GetComponent<Hunter>().takeDamage = false;
            player.GetComponent<HunterSkills>().StartAccumulationOfConcentration();
        }
    }
}
