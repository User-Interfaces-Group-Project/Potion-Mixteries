using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

//PlayerInput was generated through Unity's new input manager
//This scripts gets the inputs from that script and normalizes them
private PlayerInput playerInput;

    private void Awake() {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }
    
    public Vector2 GetMovementVectorNormalized() {

        Vector2 inputVector = playerInput.Player.Movement.ReadValue<Vector2>();

         //Normalizes movement to prevent faster speeds when going diagonally
        return inputVector.normalized;
    }
}
