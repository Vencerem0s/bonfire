using System.Collections;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public GameObject lightBolt, golem, aura;

    private Transform aurascale;
    private Vector2 aurascale1, aurascale0;
    [SerializeField] private float cdspell1, cdspell2, cdulta;

    public int hpMage;

    public Transform shotPoint;

    void Start()
    {
        aurascale1 = new Vector2(1f, 1f);
        aurascale0 = new Vector2(0f, 0f);
        hpMage = 100;
        aurascale = aura.GetComponent<Transform>();
        aurascale.localScale = aurascale0;
        cdspell1 = 5f;
        cdspell2 = 6f;
        cdulta = 20f;
    }

    void Update()
    {
        StartCoroutine(ActivateAura());
        SkillsMage();
        MovementAnimation();
    }

    void SkillsMage()
    {
        //тут надо включать анимации способностей
        if (Input.GetKeyDown(KeyCode.Q) && cdspell1 == 5f)
        {
            Instantiate(lightBolt, shotPoint.position, transform.rotation);
            StartCoroutine(CDSpellMage(cdspell1));
            cdspell1 = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.E) && cdspell2 == 6f)
        {
            BloodMagic();
            StartCoroutine(CDSpellMage(cdspell2));
            cdspell2 = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.F) && cdulta == 20f)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Instantiate(golem, worldPosition, transform.rotation);
            StartCoroutine(CDSpellMage(cdulta));
            cdulta = 0f;
        }
    }

    void BloodMagic()
    {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            gameObj.GetComponent<Enemy>().TakeDamage(50);
            gameObj.GetComponent<Enemy>().BloodLostAnimation();
            hpMage += 10;
            //запуск анимации вокруг игрока аура получения крови
        }
    }

    IEnumerator ActivateAura()
    {
        Vector2 magePos1 = GetComponent<Transform>().position;
        yield return new WaitForSeconds(2f);
        Vector2 magePos2 = GetComponent<Transform>().position;
        if (magePos1 != magePos2)
        {
            aurascale.localScale = aurascale0;
            //запуск анимации ауры
        }
        else
        {
            aurascale.localScale = aurascale1;
            //запуск анимации угасания ауры
        }
    }

    private void MovementAnimation()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
        {
            //запуск анимации ходьбы
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S))
        {
            //запуск анимации idle
        }
    }

    IEnumerator CDSpellMage(float cdtime)
    {
        yield return new WaitForSeconds(cdtime);
        
        if(cdtime == 5f)
        {
            cdspell1 = cdtime;
        }
        else if (cdtime == 6f)
        {
            cdspell1 = cdtime;
        }
        else if (cdtime == 20f)
        {
            cdspell1 = cdtime;
        }
    }
}
