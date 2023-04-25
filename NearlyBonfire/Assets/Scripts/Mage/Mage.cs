using System.Collections;
using System.Net;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public GameObject lightBolt, preGolemAnim, auraGolem1, auraGolem2, auraGolem3, golem, aura, darkSphere, golemobj;
    //private GameObject golemobj;
    private IlyaMovement movementscript;
    private Animator chAnimator;

    //private Staff Staff;

    private Vector3 startGolemPos;

    [SerializeField] private float cdspell1, cdspell2, cdulta;

    public float mana;

    public Transform shotPoint, sphereFireStartPoint;

    void Start()
    {
        GameObjectsManager.Register(gameObject);
        //Staff = GameObject.Find("Staff").GetComponent<Staff>();
        movementscript = GetComponent<IlyaMovement>();
        chAnimator = GetComponent<Animator>();
        mana = 0f;

        StartCoroutine(ActivateAura());

        cdspell1 = 5f;
        cdspell2 = 6f;
        cdulta = 20f;
    }

    void Update()
    {
        /*if (golemobj != null)
        {
            mana = 0f;
        }
        else
        {
            StartCoroutine(ActivateAura());
        }*/
        SkillsMage();
    }

    void SkillsMage()
    {
        if(movementscript.movesum != 0f)
        {
            //print(movementscript.movesum);
            return;
        }

        //тут надо включать анимации способностей
        if (Input.GetKeyDown(KeyCode.Q) && cdspell1 == 5f && golemobj == null)// && movementscript.speedMove == 0f)
        {
            movementscript.SpellDuration(2f);
            chAnimator.SetTrigger("LightSpell");//, true);
            //Instantiate(lightBolt, shotPoint.position, transform.rotation);
            StartCoroutine(CDSpellMage(cdspell1));
            cdspell1 = 0f;
            //chAnimator.SetBool("LightSpell", false);
        }
        else if (Input.GetKeyDown(KeyCode.E) && cdspell2 == 6f && golemobj == null)// && movementscript.speedMove == 0f)
        {
            movementscript.SpellDuration(3f);
            chAnimator.SetTrigger("BloodSpell");//, true);
            BloodMagic();
            StartCoroutine(CDSpellMage(cdspell2));
            cdspell2 = 0f;
            //chAnimator.SetBool("BloodSpell", false);
        }
        else if (Input.GetKeyDown(KeyCode.F) && cdulta == 20f && mana >= 100f)// && movementscript.speedMove == 0f)
        {
            movementscript.SpellDuration(4f);
            chAnimator.SetTrigger("MageUlt");//, true);
            Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseray, out hit, 100))
            {
                Instantiate(preGolemAnim, hit.point, transform.rotation);
                startGolemPos = hit.point;
            }
            /*golemobj = GameObject.FindGameObjectWithTag("golem");
            TakeMana(-100f);*/
            StartCoroutine(CDSpellMage(cdulta));
            cdulta = 0f;
            //chAnimator.SetBool("MageUlt", false);
        }
        else if (Input.GetMouseButtonDown(0))// && chAnimator.GetBool("Attack") == false)
        {
            //chAnimator.SetBool("Run", false);
            chAnimator.SetTrigger("sphereAttack");//Bool("Attack", true);
            movementscript.SpellDuration(2.2f);
        }
        else if(movementscript.speedMove != 0f && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F)))
        {
            //проигрывать звук мага отказывается колдовать на ходу
        }
    }

    void BloodMagic()
    {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if(gameObj == null)
            {
                break;
            }
            gameObj.GetComponent<Enemy>().TakeDamage(50);
            gameObj.GetComponent<Enemy>().BloodLostAnimation();
            gameObject.GetComponent<Enemy>().TakeHealth(10f);
            TakeMana(5f);
            //запуск анимации вокруг игрока аура получения крови
        }
    }

    public void ActivateAuraVoid()
    {
        StartCoroutine(ActivateAura());
    }

    IEnumerator ActivateAura()
    {
        while (true)
        {
            Vector2 magePos1 = GetComponent<Transform>().position;
            yield return new WaitForSeconds(0.002f);
            Vector2 magePos2 = GetComponent<Transform>().position;
            if (golemobj != null)
            {
                aura.SetActive(false);
                mana = 0f;
            }
            else if (magePos1 != magePos2)
            {
                aura.SetActive(false);
                //запуск анимации угасания ауры
            }
            else
            {
                aura.SetActive(true);
                yield return new WaitForSeconds(0.002f);
                TakeMana(0.0005f);
                //запуск анимации ауры
            }
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
            cdspell2 = cdtime;
        }
        else if (cdtime == 20f)
        {
            cdulta = cdtime;
        }
    }

    public void TakeMana(float manna)
    {
        if ((mana + manna) >= 100f)
        {
            mana = 100f;
        }
        else
        {
            mana += manna;
        }
    }

    public void ShootDarkSphere()
    {
        Instantiate(darkSphere, sphereFireStartPoint.position, transform.rotation);
    }
        
    public void UltExit()
    {
        Destroy(GameObject.Find("PrefabStart(Clone)"));
    }

    public void ActivateGolem()
    {
        Instantiate(golem, startGolemPos, transform.rotation);
        TakeMana(-100f);
        GolemAura(true, golem);
    }

    public void GolemAura(bool activity, GameObject golemus)
    {
        auraGolem1.SetActive(activity);
        auraGolem2.SetActive(activity);
        auraGolem3.SetActive(activity);
        golemobj = golemus;
    }

    public void LightBoltThrow()
    {
        Instantiate(lightBolt, shotPoint.position, transform.rotation);
    }
}
