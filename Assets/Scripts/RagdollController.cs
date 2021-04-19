using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public static RagdollController instance;
   
   public Material lineMaterial;
   public List<MarionetteVisuals> marionetteVisuals = new List<MarionetteVisuals>();
   private List<LineRenderer> lines = new List<LineRenderer>();
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }   
        for(int i = 0 ; i < marionetteVisuals.Count; i++)
        {
            LineRenderer line = marionetteVisuals[i].fingertip.gameObject.AddComponent<LineRenderer>();
            lines.Add(line);
            line.material = lineMaterial;
            line.startWidth = 0.01f;
            line.endWidth = 0.01f;
            line.startColor = Color.white;
            line.endColor = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
         for(int i = 0 ; i < marionetteVisuals.Count; i++)
        {
            lines[i].SetPosition(0, marionetteVisuals[i].fingertip.position);
            lines[i].SetPosition(1, marionetteVisuals[i].joint.position);

        }
    }
}
