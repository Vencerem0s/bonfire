using OpenCover.Framework.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class GameObjectsManager : MonoBehaviour
{

    public static GameObjectsManager _instanse
    {
        get
        {
            if (m_instanse == null)
            {
                var go = new GameObject("[GAME OBJECTS MANAGER]");
                m_instanse = go.AddComponent<GameObjectsManager>();
                DontDestroyOnLoad(go);
            }

            return m_instanse;
        }
    }

    private static GameObjectsManager m_instanse;

    private List<GameObject> _allObjects = new List<GameObject>();

    public static void Register(GameObject gameObject)
    {
        if (!_instanse._allObjects.Contains(gameObject))
            _instanse._allObjects.Add(gameObject);
    }

    public static void Unregister(GameObject gameObject)
    {
        if (_instanse._allObjects.Contains(gameObject))
            _instanse._allObjects.Remove(gameObject);
    }

    public static GameObject[] GetGameObjects<T>()
    {
        List<GameObject> items = new List<GameObject>();

        foreach (var entry in _instanse._allObjects)
        {
            if (entry.GetType() == typeof(T))
                items.Add(entry);
        }

        return items.ToArray();
    }

    public static GameObject[] GetGameObjectByTag(string tagName)
    {
        List<GameObject> items = new List<GameObject>();
        foreach (var entry in _instanse._allObjects)
        {
            if (entry.gameObject.tag == tagName)
            {
                items.Add(entry);
            }
        }

        return items.ToArray();
    }


    /*private void OnDestroy()
    {
        _instanse._allObjects.Clear();
    }*/

}
