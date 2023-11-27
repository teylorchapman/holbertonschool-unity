using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TargetSpawner : MonoBehaviour
{
    public GameObject theTargets;
    public int numberOftargets = 5;

    public PlaneManager planeManager;  

    private void Start()
    {
        if (planeManager == null)
        {
            Debug.LogError("Plane Manager ref is not set");
        }
    }

    public void OnStartButtonClick()
    {
        ARPlane selectedPlane = planeManager.SelectPlane();
        if (selectedPlane != null)
        {
            targetSpawn(selectedPlane);
        }
    }

    public void targetSpawn(ARPlane plane)
    {
        List<Vector3> thebounds = new List<Vector3>();
        for (int x = 0; x < numberOftargets; x++)
        {
            Vector3 location = GetRandoLocationWithinTheBounds(plane);
            GameObject target = Instantiate(theTargets, location, Quaternion.identity);
        }
    }

    private Vector3 GetRandoLocationWithinTheBounds(ARPlane plane, float margin = 0f, float pad = 0f)
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
