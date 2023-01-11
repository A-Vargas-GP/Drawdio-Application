using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerMove : MonoBehaviour
{
    [SerializeField] Vector2 XMove;
    [SerializeField] float PosX, PosY;
    [SerializeField] Camera _camera;
    [SerializeField] GameObject Sticker;
    public static bool stickerDrag;
    private AudioSource audio;
    public bool audioOn;

    // Start is called before the first frame update
    void Start()
    {
        PosX = gameObject.transform.position.x;
        PosY = gameObject.transform.position.y;
        XMove = new Vector2 (PosX, PosY);
        Camera.main.orthographic = true;
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        stickerDrag = false;
        audio = GetComponent<AudioSource>();
        audioOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = XMove;
        if(audioOn==true){
            audio.mute=false;
        }
        else{
            audio.mute=true;
        }
    }

     public void OnMouseDown(){
        XMove = _camera.ScreenToWorldPoint(Input.mousePosition);
        GameObject Xgo = Instantiate(Sticker,new Vector3(PosX,PosY,0),Quaternion.identity);
        Debug.Log("Mouse Move!");
        stickerDrag = true;
        audioOn=true;
     }

    public void OnMouseDrag(){
        XMove = _camera.ScreenToWorldPoint(Input.mousePosition);
        stickerDrag = true;
    }

    public void OnMouseUp(){
        Debug.Log("Up");
        stickerDrag = false;
}
}