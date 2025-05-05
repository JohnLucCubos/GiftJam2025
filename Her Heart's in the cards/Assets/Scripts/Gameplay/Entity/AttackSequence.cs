using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSequence : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform attackTransform;
    [SerializeField] List<Transform> attackPoints;
    List<GameObject> stars = new List<GameObject>();
    [SerializeField] GameObject attackPrefab;
    [SerializeField] GameObject circleAttackPrefab;
    [SerializeField] int frequency = 5; // Frequency of the attack in seconds
    [SerializeField] float delay = 0.5f; // Delay before the attack starts
    [SerializeField] float cooldown;
    [SerializeField] float speed = 5f; // Duration of the attack animation
    [SerializeField] bool isAttacking = false; // Flag to check if the attack is in progress

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SwitchAttacks", cooldown, cooldown);
    }

    void SwitchAttacks()
    {
        if (isAttacking) return; // Prevents multiple attacks at the same time
        switch (Random.Range(0, 2))
        {
            case 0:
                Attack();
                break;
            case 1:
                CircleAttack();
                break;
        }
    }

    void Attack()
    {
        isAttacking = true; // Set the flag to true when starting the attack
        StartCoroutine(CardCooldown());
    }

    void CircleAttack()
    {
        isAttacking = true; // Set the flag to true when starting the attack
        foreach (Transform attackPoint in attackPoints)
        {
            attackPoint.rotation = LookAtPlayer(attackPoint.position);
            GameObject prefab = Instantiate(circleAttackPrefab, attackPoint.position, attackPoint.rotation);
            stars.Add(prefab);
        }

        StartCoroutine(CooldownCircle());
    }


    Quaternion LookAtPlayer(Vector3 position)
    {
        Vector3 direction = playerTransform.position - position;
        direction.Normalize();
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;
        return Quaternion.Euler(0, 0, angle);
    }

    IEnumerator CooldownCircle()
    {
        yield return new WaitForSeconds(1f);
        int i = 0;
        foreach (Transform attackPoint in attackPoints)
        {
            GameObject prefab = stars[i];
            prefab.GetComponent<Rigidbody2D>().linearVelocity = attackPoint.up * speed; // Adjust speed as needed
            i++;
            yield return new WaitForSeconds(delay);
        }
        stars = new List<GameObject>();
        yield return new WaitForSeconds(1f);
        isAttacking = false; // Reset the flag after the attack is done
    }

    IEnumerator CardCooldown()
    {
        for (int i = 0; i < frequency; i++)
        {
            attackTransform.rotation = LookAtPlayer(attackTransform.position);
            GameObject prefab = Instantiate(attackPrefab, attackTransform.position, attackTransform.rotation);
            prefab.GetComponent<Rigidbody2D>().linearVelocity = attackTransform.up * speed; // Adjust speed as needed
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1f);
        isAttacking = false; // Reset the flag after the attack is done
    }
}
