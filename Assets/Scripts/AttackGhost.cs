using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AttackGhost : MonoBehaviour
{
    private ARRaycastManager m_ARRaycastManager;
    private PlaceGhost GhostController;
    [SerializeField] GameObject CannonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        m_ARRaycastManager = GetComponent<ARRaycastManager>();
        GhostController = gameObject.GetComponent<PlaceGhost>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attackButtonCallback()
    {
        Ray ray = new Ray(Camera.current.transform.position, Camera.current.transform.forward);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);

        if (hit.collider.gameObject.tag == "Enemy")
        {
            GhostController.DestroyGhost(hit.collider.gameObject);
        }
    }

    private IEnumerator DestroyObjectAfterSeconds(GameObject instance, float Time)
    {
        yield return new WaitForSeconds(Time);

        Destroy(instance);
    }
}
