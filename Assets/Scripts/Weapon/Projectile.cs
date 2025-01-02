using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;
    public Vector3 Direction { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }

    private void Start()
    {
        Speed = speed;
        // Invoke("DestroyProjectile", 1.5f); 
    }

    private void Update()
    {
        transform.Translate(Direction * (Speed * Time.deltaTime));
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
         DestroyProjectile();
    }
    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
