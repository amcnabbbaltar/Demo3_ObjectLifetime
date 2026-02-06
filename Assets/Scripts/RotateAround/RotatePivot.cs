using UnityEngine;

public class RotatePivot : MonoBehaviour
{
    public Transform pivot;        // Assign the pivot in Inspector
    public float rotationAmount = 90f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            pivot.Rotate(0f, rotationAmount, 0f);
        }
    }
}
