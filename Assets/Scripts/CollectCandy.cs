using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectCandy : MonoBehaviour
{
    public TextMeshProUGUI display_score;
    public GameObject placement_indicator;
    public GameObject []CandyArrObj;
    public bool Collect_but = false ;
    private Vector3 randomPos;
    private List<GameObject> list_candy;

    private int score = 0;
    private Pose placementPose = PlacementScript.placementPose;

    void Start()
    {
        display_score.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (score <= 50)
        {
            display_score.text = score.ToString();
        }

        if (list_candy.Count < 30)
        {

            randomPos = new Vector3(Random.Range(placementPose.position.x + 0.5f, placementPose.position.x - 0.5f), placementPose.position.y, Random.Range(placementPose.position.z + 0.5f, placementPose.position.z - 0.5f));

            list_candy.Add(Instantiate(CandyArrObj[Random.Range(0, CandyArrObj.Length - 1)], randomPos, Quaternion.identity)); ;
            list_candy[list_candy.Count - 1].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Collect_but)
        {
            other.transform.position = new Vector3(randomPos.x, randomPos.y,randomPos.z);
            score++;
        }
    }

    public void onPressed()
    {
        Collect_but = true;
    }

    public void offPressed()
    {
        Collect_but = false;
    }
}
