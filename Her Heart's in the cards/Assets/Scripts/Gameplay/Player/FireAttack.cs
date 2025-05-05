using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour, IAttack
{
    [SerializeField] GameObject firePrefab;
    [SerializeField] List<GameObject> fireSpawnPoint;
    [SerializeField] int speed;
    public void OnClick()
    {
        foreach (var spawnPoint in fireSpawnPoint)
        {
            GameObject fire = Instantiate(firePrefab, spawnPoint.transform.position, Quaternion.identity);
            fire.GetComponent<Rigidbody2D>().linearVelocity = Vector3.up * speed; // Set the velocity of the fire projectile
            Destroy(fire, 3f);
        }
    }
}
