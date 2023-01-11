using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brushScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      mousePos.z = 0f;
      gameObject.transform.position = mousePos;
      spriteRenderer.enabled = Input.GetMouseButton(0);  
    }
}
