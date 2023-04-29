using System.Collections;
using UnityEngine;

public sealed class CoroutinesStarterBehaviour : MonoBehaviour
{
    private static CoroutinesStarterBehaviour instanse
    {
        get
        {
            if (m_instanse == null)
            {
                var go = new GameObject("[COROUTINE MANAGER]");
                m_instanse = go.AddComponent<CoroutinesStarterBehaviour>();
                DontDestroyOnLoad(go);
            }

            return m_instanse;
        }
    }

    private static CoroutinesStarterBehaviour m_instanse;

    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return instanse.StartCoroutine(enumerator);
    }

    public static void StopRoutine(Coroutine routine)
    {
        if (routine != null)
            instanse.StopCoroutine(routine);
    }


}