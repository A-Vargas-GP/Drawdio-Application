using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DrawingScript : MonoBehaviour
{
    public GameObject brush;

    //Corner circle
    public GameObject cornerCurrColor;

    //Meant for the RGB Sliders
    public Slider sliderRed;
    public Slider sliderGreen;
    public Slider sliderBlue;
    public Slider sliderAlpha;

    //Variables meant for the RGB values
    private float red;
    private float green;
    private float blue;
    private float alpha;

    //Meant for drawing
    private LineRenderer currLineRender;
    private Vector2 prevPos;

    //Meant for position of increasing or decreasing brush obj size
    private Vector3 scaleIncrease;
    private Vector3 scaleDecrease;

    //Meant for value of the brush obj size
    private float increaseDrawingSize;
    private float decreaseDrawingSize;

    //Represents adjustment of the LineRenderer size
    private float newSize;
    
    //Meant for changing colors based on material
    private SpriteRenderer sr;
    private Color c1;

    //Meant for finding out if drop-down menu is selected (drawing would be disabled)
    public GameObject hamburger;
    private Animator animator;

    //Meant for communicating with sticker script
    public GameObject stickerSticker;
    public StickerMove stickerOn;

    //New Changing Size Selections
    public TextMeshProUGUI currSizeTxt;
    public Slider sizeSlider;

    public bool stopDrawing;

    // Start is called before the first frame update
    void Start()
    {
        //Camera.main.orthographic = true;
        scaleIncrease = new Vector3(0.1f, 0.1f, 0.1f);
        scaleDecrease = new Vector3(-0.1f, -0.1f, -0.1f);

        increaseDrawingSize = 0.1f;
        decreaseDrawingSize = -0.1f;

        newSize = 1.0f;

        brush.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        sr = brush.GetComponent<SpriteRenderer>();

        animator = hamburger.GetComponent<Animator>();

        stickerSticker = GameObject.FindWithTag("Sticker");
        stickerOn = stickerSticker.GetComponent<StickerMove>();
    }

    void StartDrawing()
    {
        if (!stopDrawing)
        {
            //Mouse is held down
            if (Input.GetKeyDown(KeyCode.Mouse0) && StickerMove.stickerDrag != true)
            {
                Brush();
            }

            //Mouse is pressed
            if (Input.GetKey(KeyCode.Mouse0) && StickerMove.stickerDrag != true)
            {
                Vector2 currMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (currMouse != prevPos)
                {
                    AddPoints(currMouse);
                    prevPos = currMouse;
                }
            }
            //Mouse is released
            else
            {
                currLineRender = null;
            }            
        }

    }

    //Creates the initial brush
    void Brush()
    {
        //Gets current mouse position on screen and adjusts brush position on z-axis
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1.0f;
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

        //Creates the brush (circle) on the screen
        GameObject brushAbility = Instantiate(brush, objPos, Quaternion.identity);

        //Uses the line renderer ability (create the line)
        currLineRender = brushAbility.GetComponent<LineRenderer>();

        FixLineRendererSize();

        //Changes the color of the line renderer based on the slider values
        ChangeLineColor();

        //Gets current mouse position on screen
        Vector2 currM_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Sets position of vertex in the line
        //Pretty much gathers the points of the line and stores them as Vector2 in an array
        //to draw the line
        //Parameters: (index, Vector3)

        //Maybe SetPositions??
        currLineRender.SetPosition(0, currM_Pos);
        currLineRender.SetPosition(1, currM_Pos);
    }

    //Continues the brush stroke
    void AddPoints(Vector2 pointPosition)
    {
        FixLineRendererSize();
        ChangeLineColor();
        currLineRender.positionCount++;
        int indexPos = currLineRender.positionCount - 1;
        currLineRender.SetPosition(indexPos, pointPosition);
    }

    public void NewChangeSize()
    {
        Vector3 newIncrease = new Vector3(sizeSlider.value, sizeSlider.value, sizeSlider.value);
        brush.transform.localScale = newIncrease;
        newSize = sizeSlider.value;

        currSizeTxt.text = newSize.ToString("0.00");
        //currSizeTxt.text = (int)newSize + "";
    }

    public void IncreaseSize()
    {
        brush.transform.localScale+=scaleIncrease;
        cornerCurrColor.transform.localScale+=scaleIncrease;
        newSize+=increaseDrawingSize;
    }

    public void DecreaseSize()
    {
        brush.transform.localScale+=scaleDecrease;
        cornerCurrColor.transform.localScale+=scaleDecrease;
        newSize+=decreaseDrawingSize;
    }

    void FixLineRendererSize()
    {
        currLineRender.widthMultiplier = newSize;
    }

    void GrabValues()
    {
        red = sliderRed.value;
        green = sliderGreen.value;
        blue = sliderBlue.value;
        alpha = sliderAlpha.value;

        c1 = new Color(red, green, blue, alpha);
    }

    void FixCircleColor()
    {
        GrabValues();
        sr.color = c1;
    }

    void ChangeLineColor()
    {
        //Grabs the values from the sliders: RBGA
        GrabValues();

        //Changes the color
        currLineRender.startColor = c1;
        currLineRender.endColor = c1;
    }

    public void OnPress()
    {
        stopDrawing = true;
    }

    public void OnRelease()
    {
        stopDrawing = false;
    }

    public void Undo()
    {
        GameObject[] currBrushes = GameObject.FindGameObjectsWithTag("brush");
        if (currBrushes != null)
        {
            int lastIndex = currBrushes.Length - 1;
            Destroy(currBrushes[lastIndex]);
        }
    }

    public void ClearAll()
    {
        GameObject[] currBrushes = GameObject.FindGameObjectsWithTag("brush");
        
        if (currBrushes != null)
        {
            foreach (GameObject brush in currBrushes)
            {
                Destroy(brush);
            }
        }
    }

    public void ChangeRedColor()
    {
        sliderRed.value = 1;
        sliderGreen.value = 0;
        sliderBlue.value = 0;
        sliderAlpha.value = 1;
    }

    public void ChangeOrangeColor()
    {
        sliderRed.value = 1;
        sliderGreen.value = 0.4f;
        sliderBlue.value = 0;
        sliderAlpha.value = 1;
    }

    public void ChangeYellowColor()
    {
        sliderRed.value = 1;
        sliderGreen.value = 1;
        sliderBlue.value = 0;
        sliderAlpha.value = 1;
    }

    public void ChangeGreenColor()
    {
        sliderRed.value = 0.1f;
        sliderGreen.value = 1;
        sliderBlue.value = 0;
        sliderAlpha.value = 1;
    }

    public void ChangeBlueColor()
    {
        sliderRed.value = 0;
        sliderGreen.value = 0;
        sliderBlue.value = 1;
        sliderAlpha.value = 1;
    }

    public void ChangePurpleColor()
    {
        sliderRed.value = 0.5f;
        sliderGreen.value = 0;
        sliderBlue.value = 1;
        sliderAlpha.value = 1;
    }    
    
    public void ChangePinkColor()
    {
        sliderRed.value = 1;
        sliderGreen.value = 0;
        sliderBlue.value = 0.7f;
        sliderAlpha.value = 1;
    }    

    public void ChangeBlackColor()
    {
        sliderRed.value = 0;
        sliderGreen.value = 0;
        sliderBlue.value = 0;
        sliderAlpha.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        StartDrawing();
        FixCircleColor();
        Debug.Log(stopDrawing);
    }
}