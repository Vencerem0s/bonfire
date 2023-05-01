using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField] private float _secondBeforeDestroy;
    void Start()
    {
        Destroy(gameObject, _secondBeforeDestroy);
    }
}
