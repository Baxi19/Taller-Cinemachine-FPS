using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    CharacterController characterController;
    public float walkSpeed = 2.0f;
    public float runSpeed = 5.0f;
    public float jumpSpeed = 4.0f;
    public float gravity = 20.0f;

    private Vector3 move = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            float rotY = Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, rotY, 0);
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                move = transform.TransformDirection(move) * runSpeed;
            }
            else
            {
                move = transform.TransformDirection(move) * walkSpeed;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                move.y = jumpSpeed;
            }
        }
        move.y -= gravity * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);
    }
}
