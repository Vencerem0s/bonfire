using UnityEngine;

public class XrossingEnemy : MonoBehaviour
{
    private GameObject opponent;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
        {
            opponent = null;

        }
        else
        {
            Debug.Log("peres");
            opponent = collision.gameObject;
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        opponent = null;
    }*/

    public void DamageDeal()
    {
        if (opponent != null)
        {
            opponent.GetComponent<SquareHP>().HPMinus();
        }
    }
}
