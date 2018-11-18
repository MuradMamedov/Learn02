using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Movement")]
public class Movement : MonoBehaviour
{
    public float speed  = 9.0f;
    public float jumpHeight  = 40.0f;

    private CharacterController _characterController;
    private float gravity = -9.8f;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = gravity;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        if (Input.GetKey(KeyCode.Space))
        {
            deltaY = jumpHeight;
        }
        var movement = new Vector3(deltaX, deltaY, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
