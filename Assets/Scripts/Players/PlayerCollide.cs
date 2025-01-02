using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int collisionCountToDestroy = 20;
    private int currentCollisionCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentCollisionCount++;
            if (currentCollisionCount >= collisionCountToDestroy)
            {
                DestroyPlayer();
            }
        }
    }

    private void Update()
    {
        if (currentCollisionCount > 0)
        {
            InvokeRepeating("DecreaseCollisionCount", 12f, 12f);
        }
    }

    private void DecreaseCollisionCount()
    {
        currentCollisionCount--;
        Debug.Log("Collision count decreased. Current count: " + currentCollisionCount);
        if (currentCollisionCount <= 0)
        {
            CancelInvoke("DecreaseCollisionCount"); 
        }
    }
    private void DestroyPlayer()
    {
        Debug.Log("Player destroyed!");
        Destroy(gameObject);
    }
}
