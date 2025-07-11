using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplotchPool : MonoBehaviour
{
    // Singleton for easy global access
    public static SplotchPool Instance;

    // Prefabs of different splotch styles (drag into inspector)
    [SerializeField] private GameObject[] splotchPrefabs;

    // Number of splotches to pre-create
    [SerializeField] private int poolSize = 5;

    // Queue to hold reusable splotches
    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        // Set up singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        // Preload splotches into pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject prefab = GetRandomSplotchPrefab();
            GameObject splotch = Instantiate(prefab, transform);
            splotch.SetActive(false);
            pool.Enqueue(splotch);
        }
    }

    // Spawn a splotch at a given position in 2D space
    public void SpawnSplotch(Vector2 position)
    {
        GameObject splotch;

        // Reuse from pool or create new if empty
        if (pool.Count > 0)
        {
            splotch = pool.Dequeue();
        }
        else
        {
            GameObject prefab = GetRandomSplotchPrefab();
            splotch = Instantiate(prefab, transform);
        }

        // Set position (Z = 0 for 2D), random rotation, and random scale
        splotch.transform.position = new Vector3(position.x, position.y, 0f);
        splotch.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        splotch.transform.localScale *= Random.Range(0.9f, 1.1f);

        splotch.SetActive(true);

        // Re-enqueue for recycling
        pool.Enqueue(splotch);
    }

    // Manually return splotch to pool (for fading, etc.)
    public void ReturnSplotch(GameObject splotch)
    {
        splotch.SetActive(false);
        pool.Enqueue(splotch);
    }

    // Helper to randomly choose one of the assigned prefab variants
    private GameObject GetRandomSplotchPrefab()
    {
        if (splotchPrefabs.Length == 0)
        {
            Debug.LogError("No splotch prefabs assigned to SplotchPool!");
            return null;
        }

        return splotchPrefabs[Random.Range(0, splotchPrefabs.Length)];
    }
}
