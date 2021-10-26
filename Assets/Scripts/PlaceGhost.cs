using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceGhost : MonoBehaviour
{
    [SerializeField] private GameObject GhostPrefab;
    [SerializeField] private int maxGhosts;

    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private ARSessionOrigin arSessionOrigin;

    private List<GameObject> GhostInstances;

    // Start is called before the first frame update
    void Start()
    {
        GhostInstances = new List<GameObject>();
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
        arSessionOrigin = GetComponent<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        var trackables = aRPlaneManager.trackables;
        tryPlaceGhost(trackables);
        moveGhost();
    }

    private void moveGhost()
    {
        foreach (var ghost in GhostInstances)
        {
            if (Vector3.Distance(ghost.transform.position, Camera.current.transform.position) > 5)
            {
                moveGhost(ghost);
            }
        }

    }

    private void CreateGhost(Vector3 position)
    {
        var ghost = Instantiate(GhostPrefab, position, Quaternion.identity);
        GhostInstances.Add(ghost);
    }
    private void tryPlaceGhost(TrackableCollection<ARPlane> trackables)
    {

        if (GhostInstances.Count < maxGhosts)
        {
            foreach (var plane in trackables)
            {
                if (GhostInstances.Count >= maxGhosts)
                {
                    return;
                }

                CreateGhost(plane.center);
            }
        }
    }

    private void moveGhost(GameObject ghost)
    {
        var planes = aRPlaneManager.trackables;

        foreach (var plane in planes)
        {
            if (Vector3.Distance(plane.center, Camera.current.transform.position) > 1)
            {
                ghost.transform.position = plane.center;
            }
        }
    }
}
