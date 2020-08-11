/*
 * https://www.youtube.com/watch?v=_QajrabyTJc
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public CharacterController characterController;

    public Transform goundCheck;
    public float groundDistance = 1.0f;
    public LayerMask groundMask;

    public bool isGrounded;

    public float speed = 12f;

    public float gravity = -9.8f;

    public float jumpHeightDefault = 3;

    private float jumpHeight;

    private Vector3 velocity;

    void Start()
    {
        jumpHeight = jumpHeightDefault;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(goundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    public void changeJumpHeight(float jh) { jumpHeight = jh; }

    public void resetJumpHeight() { jumpHeight = jumpHeightDefault; }
}
