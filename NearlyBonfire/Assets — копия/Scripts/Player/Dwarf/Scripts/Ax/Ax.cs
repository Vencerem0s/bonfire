using UnityEngine;

public class Ax : MonoBehaviour
{
    private float _axDamage;
    private BoxCollider _boxCollider;

    private void Start()
    {
        GameObjectsManager.Register(gameObject);
        _boxCollider = GetComponent<BoxCollider>();
        //_boxCollider.enabled = false;
        _axDamage = 20f;
    }

    #region MONO
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyParametrs>().TakeDamage("physical", _axDamage);

            GameObject playerDwarf = FindDwarf();
            ChangeDwarfValues(playerDwarf);
        }
    }

    #endregion

    #region PUBLIC METHODS
    public void SetAxDamage(float axDamage)
    {
        _axDamage = axDamage;
    }
    #endregion

    #region PRIVATE METHODS
    private GameObject FindDwarf()
    {
        GameObject[] player = GameObjectsManager.GetGameObjectByTag("Player");
        GameObject playerDwarf = null;
        foreach (var item in player)
        {
            if (playerDwarf != null)
                break;

            if (item.name == "Dwarf")
                playerDwarf = item;
        }
        return playerDwarf;
    }

    private void ChangeDwarfValues(GameObject playerDwarf)
    {
        if (playerDwarf == null)
            return;

        Dwarf playerDwarfGC = playerDwarf.GetComponent<Dwarf>();

        playerDwarfGC.GetRange(5f);

        if (playerDwarfGC.CheckUltimate())
            playerDwarfGC.GetHealth(5f);
    }
    #endregion



}
