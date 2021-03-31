#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

using UnityEngine;

namespace Kozos.Player
{
    public class LookWithMouse : MonoBehaviour
    {
        private float mouseSensitivityDefault = 200f;
        float xRotation = 0f;
        float yRotation = 0f;
        public Camera cameraPlayer;
        public GameObject nyak;
        float cameraFov;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        void Update()
        {
            LookAround();
            Zoom();
        }

        private void LookAround()
        {
            var camFovOszto = cameraFov/50;
            var mouseSensitivity = mouseSensitivityDefault * camFovOszto;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -60f, 80f);
            yRotation -= mouseX;
            yRotation = Mathf.Clamp(yRotation, -120f, 120f);
            nyak.transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
        }

        private void Zoom()
        {
            float minFov = 15f;
            float maxFov = 50f;
            float sensitivity = 50f;


            
            cameraFov = cameraPlayer.fieldOfView;
            cameraFov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            cameraFov = Mathf.Clamp(cameraFov, minFov, maxFov);
            cameraPlayer.fieldOfView = cameraFov;
        }
    }
}