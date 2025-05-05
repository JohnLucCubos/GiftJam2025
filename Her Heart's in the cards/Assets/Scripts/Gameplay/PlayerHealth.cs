using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
[SerializeField] GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Projectile")) return;
        gameManager.PlayerDamage();
    }

}
