using System.Collections;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    public float initialSpawnInterval = 10f;
    public int initialGhostCount = 10;

    private float spawnInterval;
    private int ghostCount;

    private void Start()
    {
        spawnInterval = initialSpawnInterval;
        ghostCount = initialGhostCount;
        StartCoroutine(SpawnGhosts());
    }

    private IEnumerator SpawnGhosts()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            for (int i = 0; i < initialGhostCount + 5 * (int)(Time.time / 10); i++)
            {
                SpawnGhost();
            }
        }
    }

    private void SpawnGhost()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0f);
        GameObject ghost = Instantiate(ghostPrefab, randomPosition, Quaternion.identity);
        GhostMovement ghostMovement = ghost.GetComponent<GhostMovement>();
    }
}
