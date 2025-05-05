using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour, IAttack
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int speed;

    public void OnClick()
    {
        GameObject card = Instantiate(cardPrefab, spawnPoint.transform.position, Quaternion.identity);
        card.GetComponent<Rigidbody2D>().linearVelocity = Vector3.up * speed;
        Destroy(card, 3f);
    }
}
