using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCan : MonoBehaviour
{
    //Meant for communicating with sticker script
    public GameObject stickerSticker;
    public StickerMove stickerOn;

   void Start(){
        stickerSticker = GameObject.FindWithTag("Sticker");
        stickerOn = stickerSticker.GetComponent<StickerMove>();
   }

   void OnTriggerEnter2D (Collider2D col){
        Debug.Log("Collide");
        if(col.CompareTag("Sticker") && StickerMove.stickerDrag != true){
          Debug.Log("Destroyed");
          Destroy(col.gameObject);
          col.GetComponent<StickerMove>().audioOn=false;
        }
    }

    void OnTriggerStay2D (Collider2D col){
        if(col.CompareTag("Sticker") && StickerMove.stickerDrag != true){
          Debug.Log("Destroyed");
          Destroy(col.gameObject);
          col.GetComponent<StickerMove>().audioOn=false;
        }
    }
}
