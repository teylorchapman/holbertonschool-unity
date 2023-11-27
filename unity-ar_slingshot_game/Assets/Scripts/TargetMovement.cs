using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TargetMovement : MonoBehaviour
{
    private ARPlane plane; // Make sure to assign the ARPlane in the inspector
    private Vector3 targetPosition;
    public float movementSpeed = 1.0f;
    public PlaneManager planeManager;

    private void Start()
    {
        // Make sure to set up ARPlane reference in the inspector
        plane = planeManager.thePlane;

        // Set the initial target position
        SetNewTargetPosition();
    }

    private void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Check if the target has reached the destination
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Set a new random target position
            SetNewTargetPosition();
        }
    }

    private void SetNewTargetPosition()
    {
        // Get a new random position within the bounds of the ARPlane
        targetPosition = GetRandomLocationWithinTheBounds(plane);
    }

    private Vector3 GetRandomLocationWithinTheBounds(ARPlane plane, float margin = 0f, float pad = 0f)
    {
        Vector3 pCenter = plane.transform.position;
        Vector3 pExtent = new Vector3((plane.size.x / 2) - margin, 0, (plane.size.y / 2) - margin);

        pad = Mathf.Min(pad, pExtent.x, pExtent.z);

        float randoX = Random.Range(-pExtent.x + pad, pExtent.x - pad);
        float randoZ = Random.Range(-pExtent.z + pad, pExtent.z - pad);
        float yLocation = pCenter.y;

        return new Vector3(randoX + pCenter.x, yLocation, randoZ + pCenter.z);
    }
}