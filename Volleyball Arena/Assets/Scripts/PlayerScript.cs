using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerScript : MonoBehaviourPunCallbacks
{
    private float speed = 5f;

    private float jumpForce = 400f;

    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.collider.name.Equals("Ground"))
            isGrounded = true;

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.name.Equals("Ground"))
            isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
            return;

        Vector3 movement = new Vector3();
        Vector3 YAxis = new Vector3();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1f;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            YAxis.y = 1f;
            GetComponent<Rigidbody>().AddForce(YAxis * jumpForce, ForceMode.Impulse);
        }

        transform.Translate(movement * speed * Time.deltaTime);

    }
}
