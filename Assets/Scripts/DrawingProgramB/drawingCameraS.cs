using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drawingCameraS : MonoBehaviour
{

    public Camera drawingCamera;
    public RawImage overlayImage;
    // Start is called before the first frame update
    void Start()
    {
        drawingCamera.targetTexture = new RenderTexture(Screen.width,Screen.height,24);
        overlayImage.texture=drawingCamera.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
