using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_TPController : MonoBehaviour
{
    public float Speed = 7f;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
}
