using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class CamAlwaysMoveWithPlayer : MonoBehaviour
{
    public GameObject camera;
    void Update()
    {
        //move this object over to camera position
        transform.position = camera.transform.position;
    }
}
