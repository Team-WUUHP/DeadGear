using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Transform CameraPivotTransform;

    void Start()
    {
        CameraPivotTransform ??= Camera.main.transform.parent.transform;
    }

    public void LookMouse(Vector2 mouseDelta)
    {
        float xRotation = CameraPivotTransform.localRotation.eulerAngles.x;
        if (xRotation > 180f) xRotation -= 360f;

        float targetX = xRotation - (mouseDelta.y * Constant.Mouse.LOOK_SENSITIVITY);
        targetX = Mathf.Clamp(targetX, -85f, 85f);

        CameraPivotTransform.localRotation = Quaternion.Euler(targetX, 0f, 0f);

        transform.Rotate(Vector3.up * mouseDelta.x * Constant.Mouse.LOOK_SENSITIVITY);
    }
}
