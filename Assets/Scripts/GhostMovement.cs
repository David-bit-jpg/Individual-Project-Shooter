using UnityEngine;
using System.Collections;
public class GhostMovement : MonoBehaviour
{
    [SerializeField]public float moveSpeed = 10f;
    private Transform playerTransform;
    [SerializeField]private int maxProjectilesToDestroy = 10;
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
            StartMoving();
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }

    private void StartMoving()
    {
        if (playerTransform != null)
        {
            StartCoroutine(MoveToTarget(playerTransform));
        }
    }

    private IEnumerator MoveToTarget(Transform target)
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Projectile"))
        {

            Destroy(other.gameObject);
            maxProjectilesToDestroy--;
            if (maxProjectilesToDestroy <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
