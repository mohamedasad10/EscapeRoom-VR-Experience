// RotateObject.cs
// This script continuously rotates the GameObject it's attached to
// using a customizable rotation speed for each axis. Useful for visual
// effects or drawing attention to objects in the scene.


using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
