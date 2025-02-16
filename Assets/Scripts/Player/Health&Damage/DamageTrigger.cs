using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [Tooltip("Damage to apply when triggered.")]
    public int damageAmount = 1;

    private PlayerHealth playerHealth;

    private void Awake()
    {
        // Attempt to get the PlayerHealth component from the same GameObject.
        playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogError("DamageTrigger: No PlayerHealth component found on this GameObject.");
        }
    }

    // Use collision to trigger damage.
    // Ensure that the colliding object (e.g., enemy) is tagged appropriately.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
