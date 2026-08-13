using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    private Vector2 moveInput;

    void Start()
    {
        playerMovement ??= GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (moveInput != null)
            playerMovement.Move(moveInput);
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        moveInput = callbackContext.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            playerMovement.Jump();
        }
    }
}
