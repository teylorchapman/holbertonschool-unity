using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject ammoPrefab;
    public Transform slingshotOrigin;
    public float maxStretchDistance = 5f;
    public float slingshotForce = 10f;

    private GameObject currentAmmo;
    private bool isAmmoBeingDragged = false;
    private Vector3 dragStartPosition;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    HandleTouchBegin(touch.position);
                    break;
                
                case TouchPhase.Moved:
                    HandleTouchMove(touch.position);
                    break;
                
                case TouchPhase.Ended:
                    HandleTouchEnd();
                    break;
            }
        }
    }

    private void HandleTouchBegin(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.transform == slingshotOrigin)
        {
            currentAmmo = Instantiate(ammoPrefab, slingshotOrigin.position, Quaternion.identity);
            isAmmoBeingDragged = true;
            dragStartPosition = currentAmmo.transform.position;
        }
    }

    private void HandleTouchMove(Vector2 touchPosition)
    {
        if (isAmmoBeingDragged)
        {
            float stretchDistance = Mathf.Clamp(Vector3.Distance(slingshotOrigin.position, currentAmmo.transform.position), 0f, maxStretchDistance);
            currentAmmo.transform.position = slingshotOrigin.position + (slingshotOrigin.forward * stretchDistance);
        }
    }

    private void HandleTouchEnd()
    {
        if (isAmmoBeingDragged)
        {
            float stretchDistance = Vector3.Distance(slingshotOrigin.position, currentAmmo.transform.position);
            float force = Mathf.Clamp(stretchDistance, 0f, maxStretchDistance) * slingshotForce;

            Rigidbody ammoRigidBody = currentAmmo.GetComponent<Rigidbody>();
            ammoRigidBody.AddForce(currentAmmo.transform.forward * force, ForceMode.Impulse);

            isAmmoBeingDragged = false;
            currentAmmo = null;
        }
    }
}
