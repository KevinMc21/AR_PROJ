using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;

public class PlacementScript : MonoBehaviour
{
    public GameObject placementIndicator;

    [SerializeField]
    public GameObject[] CandyArrObj;

    private List<GameObject> objectArr = new List<GameObject>();

    [SerializeField]
    private ARRaycastManager arOrigin;
<<<<<<< HEAD
    private Pose placementPose;
=======
    public static Pose placementPose;
>>>>>>> 0f50f418b90c6e5bf34564677571e09f37f12bf6
    private bool placementPoseIsValid = false;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacement();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacement()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hit = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter, hit, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hit.Count > 0;
        print(placementPoseIsValid);
        Debug.Log(placementPoseIsValid);
        if (placementPoseIsValid)
        {
            placementPose = hit[0].pose;

            var cameraForawrd = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForawrd.x, 0, cameraForawrd.z).normalized;

            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }

    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
<<<<<<< HEAD



            if ( objectArr.Count < 30)
            {

                var randomPos = new Vector3(Random.Range(placementPose.position.x + 0.5f,placementPose.position.x - 0.5f),placementPose.position.y, Random.Range(placementPose.position.z + 0.5f,placementPose.position.z - 0.5f));

                objectArr.Add(Instantiate(CandyArrObj[Random.Range(0, CandyArrObj.Length-1)], randomPos, Quaternion.identity));;
                objectArr[objectArr.Count - 1].SetActive(true);
            }
=======
>>>>>>> 0f50f418b90c6e5bf34564677571e09f37f12bf6
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
};
