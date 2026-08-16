using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    private Vector3 velocity;

    private float fallSpeed;
    private bool isGrounded;

    private bool requestJump;

    void Start()
    {
        characterController ??= GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isGrounded)
            fallSpeed += Constant.Physical.GRAVITY_SCALE * Time.deltaTime;
        else
        {
            fallSpeed = Mathf.Max(fallSpeed, 0);
            if (requestJump)
                fallSpeed = Constant.Player.JUMP_FORCE;
        }
        requestJump = false;

        velocity.y = fallSpeed;

        characterController.Move(velocity * Time.deltaTime);

        isGrounded = characterController.isGrounded;
    }

    public void Move(Vector2 moveInput)
    {
        moveInput = Vector2.Normalize(moveInput) * Constant.Player.MOVE_SPEED;
        velocity = new Vector3(moveInput.x, 0, moveInput.y);
    }

    public void Jump()
    {
        requestJump = true;
    }
}