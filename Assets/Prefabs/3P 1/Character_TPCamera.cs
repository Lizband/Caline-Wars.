using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_TPCamera : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public Transform Target, Player;
    float mouseX, mouseY;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60); // Fix look clamping so player can't break neck

        transform.LookAt(Target);
        if (Input.GetKey(KeyCode.Q))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}
