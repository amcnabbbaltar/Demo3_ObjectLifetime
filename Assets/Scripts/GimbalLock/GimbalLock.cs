using UnityEngine;

public class GimbalLock : MonoBehaviour
{
    [Header("Rotation Setup")]
    public float pitchAngle = 90f; // 90 degrees aligns Y and Z axes
    public float rotateSpeed = 90f;
    
    [Header("Toggle Axis to Rotate")]
    public bool rotateAroundYaw = true; // Rotates around Y-axis
    public bool rotateAroundRoll = false; // Rotates around Z-axis

    private float currentAngle = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        currentAngle += rotateSpeed * Time.deltaTime;

        if (rotateAroundYaw)
        {
            // Apply 90° pitch first, then rotate around Y (Yaw)
            transform.eulerAngles = new Vector3(pitchAngle, currentAngle, 0f);
        }
        else if (rotateAroundRoll)
        {
            // Apply 90° pitch first, then rotate around Z (Roll)
            transform.eulerAngles = new Vector3(pitchAngle, 0f, currentAngle);
        }
    }
}
