using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    PlayerControls playerControls;
    IMovement movement;
     void Awake()
    {
        movement = GetComponent<IMovement>();
        playerControls = new PlayerControls();
        playerControls.Enable();
    }
    void Start()
    {
        playerControls.Player.Move.performed += _ => movement.Move(true, _.ReadValue<Vector2>());
        playerControls.Player.Move.canceled += _ => movement.Move(false, Vector2.zero);
    }

    void OnEnable() => playerControls.Enable();
    void OnDisable() => playerControls.Disable();
    void OnDestroy() => playerControls.Dispose();
}
