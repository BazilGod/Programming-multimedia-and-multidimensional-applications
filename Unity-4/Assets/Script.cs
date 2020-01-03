using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour {

    private Transform cameraTransform;

    //for applyForce
    public int force = 2000;

    //movement speed
    public float speed = 10;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void Start()
    {
        cameraTransform = Camera.main.transform;

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        
        moveKeys();
 
     
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

     public void moveKeys()
     {float CamSpeed = 15f;
          if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * CamSpeed);
        else if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.right * Time.deltaTime * -CamSpeed );
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.forward * Time.deltaTime * -CamSpeed );
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * CamSpeed );
       
     }

       
}
