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
    public float jumpHeight = 1f;
    public float gravity = 28f;

    public float soundCooldownMax = 0.2f;
    private float soundCooldown = 0;

    private float jumpPowerMax = 0.15f;
    private float curJumpPower = 0f;

    // this boolean keeps the first frame after dialogue ending
    // from causing the player to jump since the key bindings for
    // continuing dialogue and jumping are the same;
    private float jumpDialogueCooldownMax = 1f;
    private float jumpDialogueCooldown = 1f;

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
        if (DialogueManager.dialogueOn)
        {
            jumpDialogueCooldown = jumpDialogueCooldownMax;
            curJumpPower = 0f;
            return;
        }
        if (jumpDialogueCooldown > 0)
        {
            jumpDialogueCooldown -= Time.deltaTime;
        }

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 moveVector = transform.forward * verticalMove + transform.right * horizontalMove;

        if (controller.isGrounded && Input.GetButton("Jump") && jumpDialogueCooldown <= 0)
        {
            curJumpPower = jumpPowerMax;
        }

        moveVector.y = Jump() - gravity * Time.deltaTime;

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

    private float Jump()
    {
        if (curJumpPower <= 0)
        {
            return 0;
        }

        float retValue = Mathf.Sqrt(2 * jumpHeight * curJumpPower * gravity);
        curJumpPower -= Time.deltaTime;

        return retValue;
    }

    // rotates player model
    private void RotateCharacter(Vector3 direction)
    {
        playerModel.forward = Vector3.Lerp(transform.eulerAngles, direction, Time.deltaTime / speed);
    }
}
