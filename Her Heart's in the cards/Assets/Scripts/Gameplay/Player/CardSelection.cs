using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CardSelection : MonoBehaviour
{
    [SerializeField] float cooldownTime = 1f;
    [SerializeField] Button cardButton;
    IAttack _attack;

    void Start()
    {
        cardButton = GetComponent<Button>();
        _attack = GetComponent<IAttack>();
        cardButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if(!cardButton.interactable) return;
        
        _attack.OnClick();
        StartCoroutine(Cooldown());

        Debug.Log("Card selected!");
    }

    IEnumerator Cooldown()
    {
        cardButton.interactable = false;
        yield return new WaitForSeconds(cooldownTime);
        cardButton.interactable = true;
    }
}
