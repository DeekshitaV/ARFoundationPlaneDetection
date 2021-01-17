using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectManager : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        zombie.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            List<ARRaycastHit> allHits = new List<ARRaycastHit>();
            if( touch.phase == TouchPhase.Began)
            {
                if( raycastManager.Raycast(touch.position , allHits , TrackableType.Planes))
                {
                    zombie.transform.position = allHits[0].pose.position;
                    zombie.SetActive(true);
                }
            }
        }
    }
}
