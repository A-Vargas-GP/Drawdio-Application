using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowColor : MonoBehaviour
{
    //private SpriteRenderer sr;
    private Image sr;
    private Color c1;

    public Slider sliderRed;
    public Slider sliderGreen;
    public Slider sliderBlue;
    public Slider sliderAlpha;

    private float red;
    private float green;
    private float blue;
    private float alpha;

    //public Canvas canvas;
 
    //float h;
    //float w;
    
    // Start is called before the first frame update
    void Start()
    {
        //sr = this.GetComponent<SpriteRenderer>();
        sr = this.GetComponent<Image>();

        /*
        h = canvas.GetComponent<RectTransform>().rect.height;
        w = canvas.GetComponent<RectTransform>().rect.width;
        this.transform.position = new Vector2(w/40, h/16);
        */
    }

    // Update is called once per frame
    void Update()
    {
        ReceiveColorValues();
        sr.color = c1;
    }

    void ReceiveColorValues()
    {
        red = sliderRed.value;
        green = sliderGreen.value;
        blue = sliderBlue.value;
        alpha = sliderAlpha.value;

        //QUESTION TO ASK: Keep alpha or ignore?
        c1 = new Color(red, green, blue, alpha);
    }
}
