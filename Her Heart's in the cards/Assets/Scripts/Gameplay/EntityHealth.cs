using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("PlayerProjectile")) return;
        gameManager.EntityDamage();
    }
}
