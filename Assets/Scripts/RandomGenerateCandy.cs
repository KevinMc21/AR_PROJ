using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RandomGenerateCandy : MonoBehaviour
{
    public GameObject objects;

    private GameObject spawnNew;
    // Start is called before the first frame update

    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private List<GameObject> objectArr = new List<GameObject>();

    void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var planes = new List<ARPlane>();
        var planesmesh = new List<Mesh>();
        Debug.Log(planes.Count);
        Debug.Log(planesmesh.Count);

        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        if (aRRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {
            var hitpose = hits[0].pose;

            //foreach (var arPlanes in aRPlaneManager.trackables)
            //{
            //    arPlanes.gameObject.SetActive(false);
            //}

            //arplane

            var randomPos = new Vector3(Random.Range(hitpose.position.x + 0.5f, hitpose.position.x - 0.5f), hitpose.position.y,Random.Range(hitpose.position.x + 0.5f, hitpose.position.z - 0.5f));

            if (objectArr.Count < 3)
            {
                objectArr.Add(Instantiate(objects,randomPos, Quaternion.identity));
                objectArr[objectArr.Count - 1].SetActive(true);
            }
        }
    }
}
