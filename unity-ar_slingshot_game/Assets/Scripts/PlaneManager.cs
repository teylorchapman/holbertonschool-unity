using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneManager : MonoBehaviour
{
    public ARPlaneManager thePlaneManager;
    public ARPlane thePlane;

    public GameObject startB;
    private ARPlane plane;
   
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
                Debug.Log("Touch Began");
                int layerMask = 1 << LayerMask.NameToLayer("AR Plane");
                if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out RaycastHit hit))
                {
                    Debug.Log("Raycast hit: " + hit.transform.name);
                    ARPlane plane = hit.transform.GetComponent<ARPlane>();
                    if (plane != null && thePlane == null)
                    {
                        SelectPlane();
                    }
                }
            }
        }
    }

    public ARPlane SelectPlane()
    {
        if (thePlane != null)
        {
            Debug.Log("Plane already selected: " + thePlane.name);
            return thePlane;
        }

        
        Debug.Log("Selected Plane: " + thePlane);
        thePlaneManager.enabled = false;
        startB.SetActive(true);
        return(plane);
    }
}
