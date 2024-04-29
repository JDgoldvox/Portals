using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTextureSetUp : MonoBehaviour
{
    public Camera camera;
    public Material mat;

    void Start()
    {
        //if (camera.targetTexture != null)
        //{
        //    camera.targetTexture.Release();
        //}

        //camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        //mat.mainTexture = camera.targetTexture;
    }
}
