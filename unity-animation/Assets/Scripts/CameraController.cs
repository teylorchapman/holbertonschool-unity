using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public float rotationSpeed = 3f;
    public float minY = 0f;
    private Vector3 offset;
    private bool isRotating;
    public bool isInverted = false;
    private Quaternion initialRotation;
    
    private void Start()
    {
        offset = transform.position - player.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        Vector3 targetPosition = player.position + offset;
        targetPosition.y = Mathf.Max(targetPosition.y, minY);

        if (targetPosition.y < -10f)
        {
            targetPosition.y = 15f;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        if (Input.GetMouseButton(1))
        {
            isRotating = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            Vector3 eulerAngleDelta = new Vector3(0f, mouseX, 0f);
            Quaternion rotationDelta = Quaternion.Euler(eulerAngleDelta);
            transform.rotation *= rotationDelta;

            if (isInverted)
            {
                mouseY = -mouseY;
            }

            Vector3 currentRotation = transform.eulerAngles;
        }
    }
}