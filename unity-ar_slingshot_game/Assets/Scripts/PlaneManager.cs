using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneManager : MonoBehaviour
{
    public ARPlaneManager thePlaneManager;
    private ARPlane thePlane;

    private GameObject startB;

    void Awake()
    {
        startB.SetActive(false);
    }

   void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out RaycastHit hit))
                {
                    ARPlane plane = hit.transform.GetComponent<ARPlane>();
                    if (plane != null && thePlane == null)
                    {
                        SelectPlane(plane);
                    }
                }
            }
        }
    }

    private void SelectPlane(ARPlane plane)
    {
        if (thePlane != null)
        {

        }

        thePlane = plane;

        thePlaneManager.enabled = false;

        startB.SetActive(true);
    }
}
