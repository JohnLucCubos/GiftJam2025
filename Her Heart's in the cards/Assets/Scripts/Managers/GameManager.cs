using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] int maxEntityHealth = 100;
    [SerializeField] int currentEntityHealth = 100;
    [Header("Player")]
    [SerializeField] int maxPlayerHealth = 100;
    [SerializeField] int currentPlayerHealth = 100;
    [SerializeField] Slider playerHealthBar;

    [Header("Damage")]
    [SerializeField] int damage = 10;

    void Start()
    {
        playerHealthBar.maxValue = maxPlayerHealth;
        playerHealthBar.value = maxPlayerHealth;
        currentPlayerHealth = maxPlayerHealth;

        currentEntityHealth = maxEntityHealth;
    }

    public void PlayerDamage()
    {
        currentPlayerHealth -= damage;
        playerHealthBar.value = currentPlayerHealth;
        if (currentPlayerHealth <= 0)
        {
            Debug.Log("Player is dead!");
            // Handle player death
        }
    }
    public void EntityDamage()
    {
        currentEntityHealth -= damage;
        if (currentEntityHealth <= 0)
        {
            Debug.Log("Entity is dead!");
            // Handle entity death
        }
    }

}
