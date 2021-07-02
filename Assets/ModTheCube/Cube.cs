using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    // Rotation speed of gameobject
    public float turnSpeed;
    public float radius;
    public float spinSpeed;

    private float angle = 0.0f;
    
    void Start()
    {
        // Set cube rotation speed
        float rotationSpeed = Time.deltaTime * 15.0f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        // Move cube in a circle
        angle += turnSpeed * Time.deltaTime;
        Vector3 newPosition = new Vector3(Mathf.Cos(angle) * radius, transform.position.y, Mathf.Sin(angle) * radius);
        transform.position = newPosition;

        // Change size of the cube
        float newScale = 2.0f * Mathf.Abs(Mathf.Sin(angle));
        transform.localScale = new Vector3(newScale, newScale, newScale);

        // Change angle of rotation
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);

        // Change color
        Renderer.material.color = Color.Lerp(Color.red, Color.green, Mathf.Abs(Mathf.Sin(angle)));
    }
}
