#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

using UnityEngine;

namespace Kozos.Player
{
    public class LookWithMouse : MonoBehaviour
    {
        public float mouseSensitivity = 2f;
        float xRotation = 0f;
        float yRotation = 0f;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        void FixedUpdate()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -60f, 80f);
            yRotation -= mouseX;
            yRotation = Mathf.Clamp(yRotation, -120f, 120f);
            transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
        }
    }
}