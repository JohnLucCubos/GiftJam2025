using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SlashAttack : MonoBehaviour, IAttack
{
    [SerializeField] BoxCollider2D slashArea;
    [SerializeField] float slashDuration = 0.5f;
    public void OnClick()
    {
        slashArea.enabled = true;
        StartCoroutine(SlashCooldown());
    }
    IEnumerator SlashCooldown()
    {
        yield return new WaitForSeconds(slashDuration);
        slashArea.enabled = false;
    }
}
