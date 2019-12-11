using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CamSpeed = 15f;
    }
    public float CamSpeed = 15f;
    private bool rotate = false;
    private bool shifted = false;
    private bool ctrled = false;
    private float shiftedSpeed = 2.5f;
    private float ctrledSpeed = 2.0f;

    public float SenX = 2f, SensY = 2f;
    float moveY, moveX;
    public bool RootX = true,
    RootY = true; 
    public bool TestY = true, 
    TestX = false; 
    public Vector2 MinMax_Y = new Vector2(-40, 40), 
    MinMax_X = new Vector2(-360, 360);


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * CamSpeed *(shifted ? shiftedSpeed : 1) * (ctrled ? ctrledSpeed : 1));
        else if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.right * Time.deltaTime * -CamSpeed * (shifted ? shiftedSpeed : 1) * (ctrled ? ctrledSpeed : 1));
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.forward * Time.deltaTime * -CamSpeed * (shifted ? shiftedSpeed : 1) * (ctrled ? ctrledSpeed : 1));
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * CamSpeed * (shifted ? shiftedSpeed : 1) * (ctrled ? ctrledSpeed : 1));
        if (Input.GetKeyDown(KeyCode.LeftShift))
            shifted = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            shifted = false;
        if (Input.GetKeyDown(KeyCode.LeftControl))
            ctrled = true;
        if (Input.GetKeyUp(KeyCode.LeftControl))
            ctrled = false;
        if (Input.GetMouseButtonDown(1))
        {
            rotate = true;
            Cursor.visible = false;
        }
        if (Input.GetMouseButtonUp(1))
        { 
            rotate = false;
            Cursor.visible = true;
        }
        if (rotate)
        {
            moveY -= Input.GetAxis("Mouse Y") * SensY;
  
            moveX += Input.GetAxis("Mouse X") * SenX;
            transform.rotation = Quaternion.Euler(moveY, moveX, 0);
        }
    }
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
