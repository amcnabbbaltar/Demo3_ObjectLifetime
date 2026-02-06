using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform pivot;          // Point to rotate around
    public Vector3 axis = Vector3.up; // Rotation axis
    public float rotationAmount = 90f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            transform.RotateAround(
                pivot.position,
                axis,
                rotationAmount
            );
        }
    }
}
