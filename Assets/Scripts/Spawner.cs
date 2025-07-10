using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip("Interval at which enemies start spawning at in seconds")]
    [SerializeField] float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs = null;
    [SerializeField] float launchForce = 10f;

    private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            int randomEnemyIndex = Random.Range(0, 1);
            GameObject projectile = Instantiate(enemyPrefabs[randomEnemyIndex], GetRandomScreenEdgePosition(), Quaternion.identity);

            Vector2 dirToOrigin = (Vector2)(-projectile.transform.position.normalized);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(dirToOrigin * launchForce, ForceMode2D.Impulse);
        }
    }

    Vector3 GetRandomScreenEdgePosition()
    {
        Camera cam = Camera.main;

        // Step 1: Pick a side randomly (0=left, 1=right, 2=top, 3=bottom)
        int side = UnityEngine.Random.Range(0, 2);

        // Step 2: Get screen dimensions
        float screenX = 0f;
        float screenY = 0f;

        switch (side)
        {
            case 0: // Left
                screenX = 0f;
                screenY = UnityEngine.Random.Range(0f, Screen.height);
                break;
            case 1: // Right
                screenX = Screen.width;
                screenY = UnityEngine.Random.Range(0f, Screen.height);
                break;
            case 2: // Top
                screenX = UnityEngine.Random.Range(0f, Screen.width);
                screenY = Screen.height;
                break;
            case 3: // Bottom
                screenX = UnityEngine.Random.Range(0f, Screen.width);
                screenY = 0f;
                break;
        }

        // Step 3: Convert screen point to world point
        Vector3 screenPoint = new Vector3(screenX, screenY, cam.nearClipPlane);
        Vector3 worldPoint = cam.ScreenToWorldPoint(screenPoint);

        // Optional: Zero out z for 2D
        worldPoint.z = 0f;

        return worldPoint;
    }

    public void SetSpawnRate(float rate)
    {
        spawnRate = rate;
    }
    
    public float GetSpawnRate()
    {
        return spawnRate;
    }

}
