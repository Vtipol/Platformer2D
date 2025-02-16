using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHearts = 5;
    public int currentHearts;

    [Header("UI Reference")]
    public LifeUI lifeUI;

    private void Start()
    {
        // Set starting health to max hearts
        currentHearts = maxHearts;

        // Initialize the UI if assigned
        if (lifeUI != null)
        {
            lifeUI.Reset();
        }
        else
        {
            Debug.LogWarning("PlayerHealth: No LifeUI assigned!");
        }
    }

    /// <summary>
    /// Call this method to deal damage to the player.
    /// </summary>
    /// <param name="damageAmount">The amount of damage (number of hearts to remove)</param>
    public void TakeDamage(int damageAmount = 1)
    {
        currentHearts = Mathf.Max(currentHearts - damageAmount, 0);

        if (lifeUI != null)
        {
            // Update the UI with the new health value
            lifeUI.UpdateUI(currentHearts);
        }

        // Optionally, check for player death
        if (currentHearts <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Call this method to heal the player.
    /// </summary>
    /// <param name="healAmount">The amount of hearts to add</param>
    public void Heal(int healAmount = 1)
    {
        currentHearts = Mathf.Min(currentHearts + healAmount, maxHearts);

        if (lifeUI != null)
        {
            // Update the UI with the new health value
            lifeUI.UpdateUI(currentHearts);
        }
    }

    private void Die()
    {
        // Implement what should happen when the player dies.
        Debug.Log("Player died!");
    }
}

