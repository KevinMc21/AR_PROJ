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

        var list_candy = GameObject.FindGameObjectsWithTag("candy");

        if (list_candy.Length < 30)
        {
            Debug.Log("Create Instance");
            StartCoroutine(gen_Candy(list_candy));
        }
    }

    //Random.Range(0, CandyArrObj.Length - 1)
    private void OnTriggerEnter(Collider other)
    {
        if (Collect_but && other.tag == "candy")
        {
            //other.transform.position = new Vector3(randomPos.x, randomPos.y,randomPos.z);
            Destroy(other);
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

    IEnumerator gen_Candy(GameObject []list_candy)
    {

        yield return new WaitForSeconds(3f);

        if (list_candy.Length < 30)
        {
            Debug.Log("Create Instance");
            randomPos = new Vector3(Random.Range(placementPose.position.x + 0.5f, placementPose.position.x - 0.5f), placementPose.position.y - 10f, Random.Range(placementPose.position.z + 0.5f, placementPose.position.z - 0.5f));

            var Obj = Instantiate(CandyArrObj[Random.Range(0, CandyArrObj.Length - 1)], randomPos, Quaternion.identity);
            Obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            list_candy[list_candy.Length - 1].SetActive(true);
        }
    }
}
