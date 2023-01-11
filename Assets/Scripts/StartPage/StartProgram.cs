using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartProgram : MonoBehaviour
{
//the rect transform of the Drawdio Logo
RectTransform logoRect;
//the position of the Drawdio Logo
Vector3 logoPos;
//the anchor minimum of the Drawdio Logo
Vector2 logoMin;
//the anchor maximum of the Drawdio Logo
Vector2 logoMax;
//Pivot of the Drawdio Logo
Vector2 logoPivot;
//Drawdio Logo and background
GameObject drawdioLogo;
GameObject bkg;
//Start button Canvas Group
[SerializeField]
CanvasGroup canvasGroup;

void Start()
{
drawdioLogo = GameObject.FindWithTag("Logo");
bkg = GameObject.FindWithTag("StartBackground");
logoRect = drawdioLogo.GetComponent<RectTransform>();



logoMin = new Vector2(0.5f,0.5f);
logoMax = new Vector2(0.5f,0.5f);
logoPivot = new Vector2(0.5f,0.5f);

logoPos = new Vector3 (0f,0f,0f);
logoRect.position = logoPos;

//Start Button is fully viewable and clickable
canvasGroup.alpha = 1f; 
canvasGroup.blocksRaycasts = true;
}

void Update() 
{
//drawdioLogo.transform.position = logoPos;
logoRect.anchoredPosition = logoPos;
logoRect.anchorMin = logoMin;
logoRect.anchorMax = logoMax;
logoRect.pivot = logoPivot;
}

public void DrawStart()
{
//Start Button is invisible and unclickable
SceneManager.LoadScene("DrawingScene", LoadSceneMode.Single);
canvasGroup.alpha = 0f; 
canvasGroup.blocksRaycasts = false;
logoMin = new Vector2(1f,1f);
logoMax = new Vector2(1f,1f);
logoPos.y-=10f;
logoPos.x-=400f;
logoRect.localScale -= new Vector3 (6,6,0);
Destroy(bkg);
}
}
