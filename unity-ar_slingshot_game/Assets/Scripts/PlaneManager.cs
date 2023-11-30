using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneManager : MonoBehaviour
{
    public ARPlaneManager thePlaneManager;
    public ARPlane thePlane;

    public GameObject startB;

    private bool hasSelectedPlane;
   
    void Awake()
    {
        thePlane = null;
        hasSelectedPlane = false;
        startB.SetActive(false);
    }

   void Update()
    {
        if (Input.touchCount > 0 && !hasSelectedPlane)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                int layerMask = 1 << LayerMask.NameToLayer("AR Plane");
                if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out RaycastHit hit))
                {
                    ARPlane plane = hit.transform.GetComponent<ARPlane>();
                    thePlane = plane;
                    ///if (plane != null && thePlane == null)
                    ///{
                        SelectPlane();
                        hasSelectedPlane = true;
                    ///}
                }
            }
        }
    }

    public ARPlane SelectPlane()
    {
        thePlaneManager.enabled = false;
        startB.SetActive(true);
        return(thePlane);
    }
}
