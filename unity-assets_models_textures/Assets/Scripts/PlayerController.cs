using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Vector3 startPosition;

    private Rigidbody prb;

    private void Start()
    {
        prb = GetComponent<Rigidbody>();
        prb.constraints = RigidbodyConstraints.FreezeRotation;
        startPosition = transform.position;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;
        prb.AddForce(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y < -10f)
        {
            ResetPlayerPosition();
        }
    }

    private void Jump()
    {
        prb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetPlayerPosition()
    {
        prb.velocity = Vector3.zero;
        prb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }
}
