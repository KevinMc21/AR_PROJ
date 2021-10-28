using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField] GameObject HealthIndicator;
    [SerializeField] PlaceGhost ghostController;

    private float MaxHPLength;
    private RectTransform rt;
    private float HealthPoints;
    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = 100;
        rt = HealthIndicator.transform.GetComponent<RectTransform>();
        MaxHPLength = rt.sizeDelta.y * rt.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();
        AdjustHPBar();
    }

    void TakeDamage()
    {
        foreach (var ghost in ghostController.GhostInstances)
        {
            if (Mathf.Abs(Vector3.Distance(ghost.transform.position, Camera.current.transform.position)) < 1)
            {
                HealthPoints -= 5 * Time.deltaTime;
                if (HealthPoints <= 0)
                {
                    SceneManager.LoadScene("seventh scene");
                }
            }
        }
    }


    void AdjustHPBar()
    {
        rt.sizeDelta = new Vector2(rt.sizeDelta.x,(HealthPoints / 100) * (MaxHPLength / rt.localScale.y));
    }
}
