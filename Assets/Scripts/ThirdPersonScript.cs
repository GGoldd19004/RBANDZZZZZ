using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;

    public float senseVariable = 5f;
    public float volume = 5f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public Transform cam;

    void OnEnable()
    {
       senseVariable = PlayerPrefs.GetFloat("Sensitivity");
       volume = PlayerPrefs.GetFloat("Volume");
       Debug.Log(senseVariable.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * senseVariable;
        float vertical = Input.GetAxisRaw("Vertical") * senseVariable;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= .1f) 
        {
            float targetAngle = (Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y);
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
