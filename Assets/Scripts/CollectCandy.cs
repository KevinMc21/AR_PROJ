using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCandy : MonoBehaviour
{
    [SerializeField] private GameObject []Candy;
    [SerializeField] private int maxCandys = 30;
    [SerializeField] private TextMeshProUGUI text;

    static public int score = 0;
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private ARSessionOrigin arSessionOrigin;
    private bool on;

    [HideInInspector] public List<GameObject> CandyInstances;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        CandyInstances = new List<GameObject>();
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
        arSessionOrigin = GetComponent<ARSessionOrigin>();
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
        var trackables = aRPlaneManager.trackables;
        tryPlaceCandy(trackables);

        if (score >= 10)
        {
            SceneManager.LoadScene("seventh scene");
        }
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

    IEnumerator waitToPlace()
    {
        on = false;
        yield return new WaitForSeconds(5);
        on = true;
    }
    private void gen_Candy(Vector3 position)
    {
        var randomPosition = new Vector3(Random.Range(position.x - 1f, position.x + 1f), position.y, Random.Range(position.z - 0.3f, position.x + 0.3f));
        var candyNew = Instantiate(Candy[Random.Range(0,Candy.Length -1 )], position, Quaternion.identity);
        CandyInstances.Add(candyNew);
        StartCoroutine(waitToPlace());
    }

    public void DestroyCandy(GameObject destroy)
    {
        score++;
        foreach (var C in CandyInstances)
        {
            if (C.GetInstanceID() == destroy.GetInstanceID())
            {
                CandyInstances.Remove(C);
                Destroy(C);
                StartCoroutine(waitToPlace());
            }
        }
    }

    private void tryPlaceCandy(TrackableCollection<ARPlane> trackables)
    {
        if (!on)
        {
            return;
        }

        if (CandyInstances.Count < maxCandys)
        {
            var plane = getRandomPlane(trackables);

            gen_Candy(plane.center);
        }
    }
}
