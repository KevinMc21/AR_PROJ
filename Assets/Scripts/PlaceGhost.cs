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
    private bool canPlaceGhost;

    [HideInInspector] public List<GameObject> GhostInstances;

    // Start is called before the first frame update
    void Start()
    {
        GhostInstances = new List<GameObject>();
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
        arSessionOrigin = GetComponent<ARSessionOrigin>();
        canPlaceGhost = true;
    }

    // Update is called once per frame
    void Update()
    {
        var trackables = aRPlaneManager.trackables;
        tryPlaceGhost(trackables);
        moveGhost();
    }

    private ARPlane getRandomPlane(TrackableCollection<ARPlane> trackables)
    {
        var len = trackables.count;

        var random = Mathf.Round(Random.Range(0, len - 1));
        var current = 0;
        ARPlane last = new ARPlane();
        foreach (var plane in trackables)
        {
            if (random == current)
            {
                return plane;
            }
            else
            {
                current++;
                last = plane;
            }

        }
        return last;
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

    IEnumerator waitToPlace()
    {
        canPlaceGhost = false;
        yield return new WaitForSeconds(5);
        canPlaceGhost = true;
    }
    private void CreateGhost(Vector3 position)
    {
        var ghost = Instantiate(GhostPrefab, position, Quaternion.identity);
        GhostInstances.Add(ghost);
        StartCoroutine(waitToPlace());
    }

    public void DestroyGhost(GameObject destroy)
    {
        foreach (var ghost in GhostInstances)
        {
            if (ghost.GetInstanceID() == destroy.GetInstanceID())
            {
                GhostInstances.Remove(ghost);
                Destroy(ghost);
                StartCoroutine(waitToPlace());
            }
        }
    }
    private void tryPlaceGhost(TrackableCollection<ARPlane> trackables)
    {
        if (!canPlaceGhost)
        {
            return;
        } 

        if (GhostInstances.Count < maxGhosts)
        {
            var plane = getRandomPlane(trackables);

            CreateGhost(plane.center);
        }
    }

    private void moveGhost(GameObject ghost)
    {
        var planes = aRPlaneManager.trackables;
        var randomPlane = getRandomPlane(planes);

        ghost.transform.position = randomPlane.center;
    }
}
