using UnityEngine;
using System;

public class ColliderWrapper : MonoBehaviour
{
    public event Action<Collision2D> OnCollision;
    public event Action<Collider2D> OnTrigger;
    void Start(){
        GetComponent<SpriteRenderer>().enabled = EnemyManager.Instance.showColliders;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision?.Invoke(collision);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTrigger?.Invoke(other);
    }
}
