using UnityEngine;

public class CameraSide : MonoBehaviour
{
    private void Start()
    {
        GameObjectsManager.Register(this.gameObject);
    }
}
