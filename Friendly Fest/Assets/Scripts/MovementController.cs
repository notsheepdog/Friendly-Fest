using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // used for rotating model based on movement direction
    public Transform playerModel; 

    private CharacterController controller;
    public float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 moveVector = transform.forward * verticalMove + transform.right * horizontalMove;

        MoveCharacter(moveVector);
//        RotateCharacter(moveVector);
    }

    private void MoveCharacter(Vector3 direction)
    {
        controller.Move(direction * speed * Time.deltaTime);
    }

    // rotates player model
    private void RotateCharacter(Vector3 direction)
    {
        playerModel.forward = Vector3.Lerp(transform.eulerAngles, direction, Time.deltaTime / speed);
    }
}
