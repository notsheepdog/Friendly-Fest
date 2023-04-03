using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // used for rotating model based on movement direction
    public Transform playerModel;
    public AudioClip walkSFX;

    private CharacterController controller;
    public float speed = 10f;

    public float soundCooldownMax = 0.2f;
    private float soundCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (soundCooldown >= 0)
        {
            soundCooldown -= Time.deltaTime;
        }
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

        if (direction != Vector3.zero && soundCooldown <= 0)
        {
            AudioSource.PlayClipAtPoint(walkSFX, transform.position, 20);
            soundCooldown = soundCooldownMax;
        }
    }

    // rotates player model
    private void RotateCharacter(Vector3 direction)
    {
        playerModel.forward = Vector3.Lerp(transform.eulerAngles, direction, Time.deltaTime / speed);
    }
}
