using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] int maxEntityHealth = 100;
    [SerializeField] int currentEntityHealth = 100;
    [Header("Player")]
    [SerializeField] int maxPlayerHealth = 1000;
    [SerializeField] int currentPlayerHealth = 100;
    public int getcurrentPlayerHealth {get { return currentPlayerHealth; } }
    [SerializeField] Slider playerHealthBar;

    [Header("Damage")]
    [SerializeField] int damage = 10;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject WinScreen;
    private bool playerWon = false;
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
        if (currentPlayerHealth <= 0 && !playerWon)
        {
            GameOverScreen.SetActive(true);
        }
    }
    public void EntityDamage()
    {
        currentEntityHealth -= damage;
        if (currentEntityHealth <= 0)
        {
            playerWon = true;
            WinScreen.SetActive(true);
        }
    }

}
