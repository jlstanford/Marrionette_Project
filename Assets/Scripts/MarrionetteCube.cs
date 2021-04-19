using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarrionetteCube : MonoBehaviour
{
    public Material cubeMaterial;
    public Material cubeCollidedMaterial;

    private ManoGestureContinuous grab;
    private Renderer cubeRenderer;
    private ManoGestureContinuous pinch;
    // Start is called before the first frame update
    void Start()
    {
        grab = ManoGestureContinuous.CLOSED_HAND_GESTURE;
        pinch = ManoGestureContinuous.HOLD_GESTURE;

        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material = cubeMaterial;
        cubeRenderer.sharedMaterial = cubeMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cubeRenderer.sharedMaterial = cubeCollidedMaterial;
            Handheld.Vibrate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        cubeRenderer.sharedMaterial = cubeMaterial;
    }

    public void OnTriggerStay(Collider other)
    {
        MoveWithHand(other);
    }

    public void MoveWithHand(Collider other)
    {
        if(ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == grab)
        {
            transform.parent = other.transform;
        } else
        {
            transform.parent = null;
        }
    }
}
