using UnityEngine;
using System.Collections;

public class TimeFreezer : MonoBehaviour
{
    private static TimeFreezer _instance;

    public static TimeFreezer Instance
    {
        get
        {
            if (_instance == null)
            {
                // Try to find an existing instance
                _instance = FindObjectOfType<TimeFreezer>();

                if (_instance == null)
                {
                    // Create new GameObject with TimeFreezer
                    GameObject go = new GameObject("TimeFreezer");
                    _instance = go.AddComponent<TimeFreezer>();

                    // Optional: Prevent from being destroyed on scene load
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Prevent duplicate instances
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void DoFreeze(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(DoTimeFreeze(duration));
    }

    private IEnumerator DoTimeFreeze(float duration)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }

    public static void FreezeTime(float duration)
    {
        Instance.DoFreeze(duration);
    }
}
