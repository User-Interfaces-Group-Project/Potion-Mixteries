using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 7f;
    [SerializeField]
    public float rotationSpeed = 10f;
    [SerializeField]
    private GameInput gameInput;

    private bool isMoving;

    private void Update()
    {
        
        //Retrieves normalized input from player input
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        //Converts Vector2 input to Vector3
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        //Movement the value of the input vector is added to the possition of the current object's transform, framerate independent
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        //checks if the player is moving
        isMoving = moveDir != Vector3.zero;

        //This is for rotating the player model
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);

    }
    
    public bool IsMoving() {
        return isMoving;
    }
}
