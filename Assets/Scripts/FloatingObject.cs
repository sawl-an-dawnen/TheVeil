using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    // Variables for bobbing (floating up and down)
    public float bobbingAmplitude = 0.5f;  // Height of the bobbing motion
    public float bobbingFrequency = 1f;    // Speed of the bobbing motion

    // Variables for rotation
    public float rotationSpeedX = 30f;  // Rotation speed around the X-axis in degrees per second
    public float rotationSpeedY = 30f;  // Rotation speed around the Y-axis in degrees per second

    // Initial position of the object
    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    void Update()
    {
        // Bobbing effect: calculate the new position
        float newY = initialPosition.y + Mathf.Sin(Time.time * bobbingFrequency) * bobbingAmplitude;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);

        // Rotation effect: rotate the object around its X and Y axes
        transform.Rotate(Vector3.right, rotationSpeedX * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationSpeedY * Time.deltaTime);
    }
}
