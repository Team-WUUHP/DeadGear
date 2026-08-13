using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    private float fallSpeed;
    private bool isGrounded;

    void Start()
    {
        characterController ??= GetComponent<CharacterController>();
    }

    void Update()
    {
        Debug.Log(fallSpeed);

        if (!isGrounded)
            fallSpeed += Constant.Physical.GRAVITY_SCALE * Time.deltaTime;
        else
            fallSpeed = Mathf.Max(fallSpeed, 0);

        Debug.Log(fallSpeed);

        characterController.Move(Vector3.up * fallSpeed);

        isGrounded = characterController.isGrounded;
    }

    public void Move(Vector2 MoveInput)
    {
        Vector3 velocity = new Vector3(MoveInput.x, 0, MoveInput.y);

        characterController.Move(velocity * Constant.Player.MOVE_SPEED * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            fallSpeed = Constant.Player.JUMP_FORCE;
        }
    }
}
