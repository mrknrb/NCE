#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
public class LookWithMouse : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    /*
    private float x;
    private float y;
    private Vector3 rotateValue;
 
    void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue*mouseSensitivity;
    }*/
   void Start()
    {
   
        Cursor.lockState = CursorLockMode.Locked;
           
    }
   
  

   

    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void FixedUpdate()
    { 
       
#if ENABLE_INPUT_SYSTEM
        float mouseX = 0, mouseY = 0;

        if (Mouse.current != null)
        {
            var delta = Mouse.current.delta.ReadValue() / 15.0f;
            mouseX += delta.x;
            mouseY += delta.y;
        }
        if (Gamepad.current != null)
        {
            var value = Gamepad.current.rightStick.ReadValue() * 2;
            mouseX += value.x;
            mouseY += value.y;
        }

        mouseX *= mouseSensitivity * Time.deltaTime;
        mouseY *= mouseSensitivity * Time.deltaTime;
#else
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
#endif

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, -160f, 160f);


        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);

    }
}
