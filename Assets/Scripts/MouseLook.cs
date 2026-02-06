using UnityEngine;

public class CameraTurnX : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    public Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Rotate player horizontally only
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
