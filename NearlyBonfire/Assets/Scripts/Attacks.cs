using UnityEngine;

public class Attacks : MonoBehaviour
{
    private GameObject _weapon;
    private Staff staff;
    private Animator _chAnimator;

    private void Start()
    {
        _chAnimator = GetComponent<Animator>();
        if (GameObject.Find("Dwarf"))
        {
            GameObject.Find("Dwarf").GetComponent<Movement>().speedMove = 4f;
            Debug.Log("функция для атаки гнома");
        }
        else if(GameObject.Find("Mage"))
        {
            GameObject.Find("Mage").GetComponent<Movement>().speedMove = 4f;
            _weapon = GameObject.Find("Staff");
            staff = _weapon.GetComponent<Staff>();
            Debug.Log("функция для атаки мага");
        }
        else if(GameObject.Find("Hunter"))
        {
            GameObject.Find("Hunter").GetComponent<Movement>().speedMove = 7f;
            //_weapon = GameObject.Find("Bow");
            //_bow = _weapon.GetComponent<Bow>();
        }
        else
        {
            Start();
        }
    }

    //private void Update()
    //{
    //    //CharacterAttack();
    //}

    //private void CharacterAttack()
    //{
    //    //if (Input.GetKeyDown(KeyCode.Mouse0))
    //    //{
    //    //    //_chAnimator.SetBool("Attack", true);
    //    //    _chAnimator.SetTrigger("asd");
    //    //    _bow.Shoot();
    //    //}
    //    //else _chAnimator.SetBool("Attack", false);
    //}

    //private void OnMouseDown()
    //{
    //    if (weapon.name == "Bow")
    //    {
    //        bow.Shoot();
    //    }
    //}

    //private void OnMouseDrag()
    //{
    //    if (weapon.name == "Staff")
    //    {
    //        staff.StaffSpell();
    //    }
    //}

    //private void OnMouseUp()
    //{
    //    if (weapon.name == "Staff")
    //    {
    //        staff.StaffSpellOff();
    //    }
    //}
    //    if (weapon.name == "Staff")
    //    {
    //        //staff.StaffSpell();
    //    }
    //}

    //private void OnMouseUp()
    //{
    //    if (weapon.name == "Staff")
    //        {
    //            //staff.StaffSpellOff();
    //        }
    //    }
}
