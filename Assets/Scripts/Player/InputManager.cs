using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private PlayerRotate playerRotate;

    private Vector2 moveInput;

    private Vector2 mouseDeltaInput;

    void Start()
    {
        playerMovement ??= GetComponent<PlayerMovement>();
        playerRotate ??= GetComponent<PlayerRotate>();
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

    public void OnLookMouse(InputAction.CallbackContext context)
    {
        mouseDeltaInput = context.ReadValue<Vector2>();
    }
}
