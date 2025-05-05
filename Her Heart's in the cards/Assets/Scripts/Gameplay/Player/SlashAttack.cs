using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SlashAttack : MonoBehaviour, IAttack
{
    [SerializeField] BoxCollider2D slashArea;
    [SerializeField] float slashDuration = 0.5f;
    [SerializeField] Animator _anim;
    [SerializeField] SpriteRenderer _renderer;

    private static readonly int slash = Animator.StringToHash("Slash");
    private static readonly int empty = Animator.StringToHash("Empty");
    public void OnClick()
    {
        slashArea.enabled = true;
        StartCoroutine(SlashCooldown());
    }
    IEnumerator SlashCooldown()
    {
        _anim.CrossFade(slash, 0.1f, 0, 0.1f);
        yield return new WaitForSeconds(slashDuration);
        _anim.CrossFade(empty, 0.1f, 0, 0.1f);
        slashArea.enabled = false;
    }
}
