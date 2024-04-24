using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class CamAlwaysMoveWithPlayer : MonoBehaviour
{
    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.transform.position;
    }
}
