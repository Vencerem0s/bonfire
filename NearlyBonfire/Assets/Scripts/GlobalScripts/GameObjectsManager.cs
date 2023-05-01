using OpenCover.Framework.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class GameObjectsManager : MonoBehaviour
{
    public static GameObjectsManager _instance;
    //{
    //    //get
    //    //{
    //    //    if (m_instance == null)
    //    //    {
    //    //        var go = new GameObject("[GAME OBJECTS MANAGER]");
    //    //        m_instance = go.AddComponent<GameObjectsManager>();

    //    //        if (Application.isPlaying)
    //    //            DontDestroyOnLoad(go);
    //    //    }

    //    //    return m_instance;
    //    //}
    //}

    public static GameObjectsManager m_instance;

    private List<GameObject> _allObjects = new List<GameObject>();

    private void Awake()
    {
        //Object[] singltons = FindObjectsOfType(typeof(GameObjectsManager));
        //if (singltons.Length > 1)
        //{
        //    m_instance = (GameObjectsManager)singltons[0];
        //    Destroy(gameObject);
        //}
        if (_instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
<<<<<<< HEAD
            

        
=======



>>>>>>> a2d3e6fd1f097b1e2d30a4623ce0feb5352b333c
    }

    public static void Register(GameObject gameObject)
    {
        if (!_instance._allObjects.Contains(gameObject))
            _instance._allObjects.Add(gameObject);
    }

    public static void Unregister(GameObject gameObject)
    {
        if (_instance._allObjects.Contains(gameObject))
            _instance._allObjects.Remove(gameObject);
    }

    public static GameObject[] GetGameObjects<T>()
    {
        List<GameObject> items = new List<GameObject>();

        foreach (var entry in _instance._allObjects)
        {
            if (entry.GetType() == typeof(T))
                items.Add(entry);
        }

        return items.ToArray();
    }

    public static GameObject[] GetGameObjectByTag(string tagName)
    {
        List<GameObject> items = new List<GameObject>();
        foreach (var entry in _instance._allObjects)
        {
            if (entry.gameObject.tag == tagName)
                items.Add(entry);
        }

        return items.ToArray();
    }

    //private void OnDestroy()
    //{
    //    if (!Application.isPlaying)
    //        Destroy(gameObject);
    //}

}
