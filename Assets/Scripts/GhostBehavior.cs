using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GhostBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    ARSessionOrigin m_SessionOrigin; 
    void Awake()
    {
        m_SessionOrigin = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        LookToPlayer();
    }

    void LookToPlayer()
    {
        var playerPos = Camera.current.transform.position;

        transform.LookAt(playerPos);
    }
}
