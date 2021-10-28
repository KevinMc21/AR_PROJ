using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCandyListener : MonoBehaviour
{

    private bool butPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "candy" && butPressed)
        {
            GetComponent<CollectCandy>().DestroyCandy(collision.gameObject);
            CollectCandy.score++;
            Debug.Log("Collect Candy");
        }
    }

    public void pressed()
    {
        butPressed = true;
    }

    public void release()
    {
        butPressed = false;
    }
}
