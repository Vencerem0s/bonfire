//скрипт получает дпс с посоха и наносит дпс врагу

using UnityEngine;

public class DarkSphereSC : MonoBehaviour
{
    
    [SerializeField] float speed = 2f;
    
    public GameObject sphere1, sphere2;

    public float curDps;

    private SphereCollider myCollider;

    void Start()
    {
        ParticleSystem ps1 = sphere1.GetComponent<ParticleSystem>();
        var vps1 = ps1.main;
        //vps1.startSize = new ParticleSystem.MinMaxCurve(5, 10);

        ParticleSystem ps2 = sphere2.GetComponent<ParticleSystem>();
        var vps2 = ps2.main;
        //vps2.startSize = new ParticleSystem.MinMaxCurve(5, 10);

        float manna = GameObject.FindGameObjectWithTag("Player").GetComponent<Mage>().mana;

        myCollider = GetComponent<SphereCollider>();
        //float radiusCollider = myCollider.radius;
        /*var fstscale1 = sphere1.GetComponent<ParticleSystem>().startSize;
        var fstscale2 = new ParticleSystem.MinMaxCurve(5, 10);*/
        curDps = manna / 3;
        if (curDps <= 10)
        {
            curDps = 10;
        }

        float cdaInScale = manna / 100;
        //print(cdaInScale);
        if (cdaInScale > 0.3f)
        {
            myCollider.radius = cdaInScale;
            vps1.startSize = cdaInScale;
            vps2.startSize = new ParticleSystem.MinMaxCurve(cdaInScale, 5f);
            //GetComponent<Transform>().localScale = new Vector3(cdaInScale, cdaInScale, cdaInScale);
        }
        else
        {
            myCollider.radius = 0.1f;
            vps1.startSize = 0.2f;
            vps2.startSize = new ParticleSystem.MinMaxCurve(0.2f, 1);
            //GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(transform.position.z > 56f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(curDps);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Mage>().TakeMana(5f);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
