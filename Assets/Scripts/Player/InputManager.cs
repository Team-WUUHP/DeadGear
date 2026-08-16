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
        playerMovement.Move(moveInput);
        playerRotate.LookMouse(mouseDeltaInput);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerMovement.Jump();
        }
    }
}
