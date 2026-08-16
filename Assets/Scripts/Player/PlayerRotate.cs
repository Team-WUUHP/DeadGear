using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Transform CameraPivotTransfotm;
    [SerializeField] private Transform PlayerTransform;

    public void LookMouse(Vector2 mouseDelta)
    {
        float xRotation = CameraPivotTransfotm.localRotation.eulerAngles.x;
        if (xRotation > 180f) xRotation -= 360f;

        float targetX = xRotation - (mouseDelta.y * Constant.Mouse.LOOK_SENSITIVITY);
        targetX = Mathf.Clamp(targetX, -85f, 85f);

        CameraPivotTransfotm.localRotation = Quaternion.Euler(targetX, 0f, 0f);

        PlayerTransform.Rotate(Vector3.up * mouseDelta.x * Constant.Mouse.LOOK_SENSITIVITY);
    }
}
