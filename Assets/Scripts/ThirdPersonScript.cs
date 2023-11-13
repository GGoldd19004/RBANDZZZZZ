using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonScript : MonoBehaviour
{
    public CharacterController controller;
    private Animator anim;
    public float senseVariable = 5f;
    public float volume = 5f;
    //Jumping
    public float jumpHeight;
    public float gravity;
    bool grounded;
    Vector3 velocity;
    
    //Movement
    private Vector2 movement;
    public float walkSpeed;
    public float sprintSpeed;
    private bool sprinting;
    private float trueSpeed;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public Transform cam;

    void OnEnable()
    {
       senseVariable = PlayerPrefs.GetFloat("Sensitivity");
       volume = PlayerPrefs.GetFloat("Volume");
       trueSpeed = walkSpeed;
       anim = GetComponentInChildren<Animator>();
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(transform.position, 1f, 1);
        anim.SetBool("isGrounded", grounded);
        if (grounded && velocity.y < 0)
        {
            velocity.y = -1;
        }

        anim.transform.localPosition = Vector3.zero;
        anim.transform.localEulerAngles = Vector3.zero;
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0f, movement.y).normalized;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            trueSpeed = sprintSpeed;
            sprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            trueSpeed = walkSpeed;
            sprinting = false;
        }
        if (direction.magnitude >= .1f) 
        {
            float targetAngle = (Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y);
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * trueSpeed * Time.deltaTime);
            if (sprinting == true)
            {
                anim.SetFloat("Speed", 2);
            }
            else
            {
                anim.SetFloat("Speed", 1);
            }
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    //Jumping

    if (Input.GetButtonDown("Jump") && grounded)
    {
        velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);
    }

    if (velocity.y > -20)
    {
        velocity.y += (gravity * 10) - Time.deltaTime;
    }

        controller.Move(velocity * Time.deltaTime);
    }
}
