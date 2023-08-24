using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float rotationalSpeed = 100f;
    public Vector3 startPosition;

    private Rigidbody prb;
    private bool canMove = false;
    private bool isGrounded = true;

    public AudioClip footstepsRunningGrass;
    public AudioClip footstepsRunningRock;

    private AudioSource audioSource;
    public AudioMixerGroup runningAudioMixerGroup;

    private void Start()
    {
        prb = GetComponent<Rigidbody>();
        prb.constraints = RigidbodyConstraints.FreezeRotation;
        startPosition = transform.position;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!canMove) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float horizontalRotation = moveHorizontal;

        transform.Rotate(0f, horizontalRotation * rotationalSpeed * Time.deltaTime, 0f);

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;

        if (movement.magnitude > 0.1f && prb.velocity.magnitude > 0.1f && isGrounded)
        {
            if (!audioSource.isPlaying)
            {
                PlayFootstepSound();
            }
        }

        if ((movement.magnitude <= 0.1f || prb.velocity.magnitude <= 0.1f || !isGrounded) && audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.loop = false;
        }

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
        isGrounded = false;
    }

    private void ResetPlayerPosition()
    {
        prb.velocity = Vector3.zero;
        prb.angularVelocity = Vector3.zero;
        transform.position = startPosition;

        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, Vector3.down, out hit))
        //{
        //  if (hit.collider.PlayOneShot(footstepsLandingGrass);
        //}
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    private void PlayFootstepSound()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.CompareTag("Grass"))
            {
                audioSource.PlayOneShot(footstepsRunningGrass);
            }
            else if (hit.collider.CompareTag("Stone"))
            {
                audioSource.PlayOneShot(footstepsRunningRock);
            }

            audioSource.loop = true;

            audioSource.outputAudioMixerGroup = runningAudioMixerGroup;

            audioSource.Play();
        }
    }
}