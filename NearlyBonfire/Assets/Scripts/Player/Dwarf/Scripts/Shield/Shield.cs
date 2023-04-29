using UnityEngine;

public class Shield : MonoBehaviour
{
    private float _shieldDamage, _stunTime;
    private BoxCollider _boxCollider;

    private void Start()
    {
        GameObjectsManager.Register(gameObject);
        _boxCollider = GetComponent<BoxCollider>();
        //_boxCollider.enabled = false;
    }

    #region MONO
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_shieldDamage);
            collision.gameObject.GetComponent<TestEnemy>().Stun(_stunTime);
        }
        else if (collision.gameObject.CompareTag("Boss"))
            Debug.Log("the shield hit the boss");

    }
    #endregion

    #region PUBLIC METHODS
    public void SetShieldValues(float shieldDamage, float stunTime)
    {
        _shieldDamage = shieldDamage;
        _stunTime = stunTime;
    }
    #endregion

    #region PRIVATE METHODS

    #endregion
}
