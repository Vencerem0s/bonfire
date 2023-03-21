using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public GameObject lightBolt, golem, aura;

    private Transform aurascale;
    private Vector2 aurascale1, aurascale0;
    //private Vector2 aurascale0;

    public int hpMage;

    public Transform shotPoint;

    void Start()
    {
        aurascale1 = new Vector2(1f, 1f);
        aurascale0 = new Vector2(0f, 0f);
        hpMage = 100;
        aurascale = aura.GetComponent<Transform>();
        aurascale.localScale = aurascale0;
    }

    void Update()
    {
        StartCoroutine(ActivateAura());
        SkillsMage();
    }

    void SkillsMage()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(lightBolt, shotPoint.position, transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            BloodMagic();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Instantiate(golem, worldPosition, transform.rotation);
        }
    }

    void BloodMagic()
    {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            gameObj.GetComponent<Enemy>().TakeDamage(50);
            hpMage += 10;
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
        }
        else
        {
            aurascale.localScale = aurascale1;
        }
    }
}
