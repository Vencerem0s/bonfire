using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class LordOrcSC : MonoBehaviour
{
    [SerializeField] GameObject _heal, _archer;
    private bool _stop = false;

    void Start()
    {
        Instantiate(_heal, transform.position, transform.rotation);
        Instantiate(_heal, transform.position, transform.rotation);
        Instantiate(_archer, transform.position, transform.rotation);
        Instantiate(_archer, transform.position, transform.rotation);
        /*ArcherSum();
        HealSum();*/
        GameEventManger.SummonEscort += SummonEscort;
    }

    private void SummonEscort(string name)
    {
        if (name.Contains("GoblinMageHeal"))
        {
            HealSum();
        }
        else if (name.Contains("GoblinArcherOrcLord"))
        {
            ArcherSum();
        }
    }

    public async void ArcherSum()
    {
        await Task.Delay(3000);

        if (_stop)
        {
            return;
        }
        
        Instantiate(_archer);
    }

    public async void HealSum()
    {
        await Task.Delay(3000);

        if (_stop)
        {
            return;
        }

        Instantiate(_heal);
    }

    private void OnApplicationQuit()
    {
        _stop = true;
    }

    private void OnDestroy()
    {
        GameEventManger.SummonEscort -= SummonEscort;
    }
}
