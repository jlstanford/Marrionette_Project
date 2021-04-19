using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmCollision : MonoBehaviour
{
    private Vector3 position;
    private TrackingInfo handTracking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handTracking = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;
        Vector3 palmPosition = new Vector3(handTracking.palm_center.x,handTracking.palm_center.y,handTracking.depth_estimation);
        position = Camera.main.ViewportToWorldPoint(palmPosition);

        transform.position = position;
    }
}
