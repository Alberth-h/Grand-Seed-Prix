using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanelOrientation : MonoBehaviour
{
    [SerializeField] private RectTransform pnlCode;
    [SerializeField] private float heightPortraitPnlCode;
    [SerializeField] private float heightLandscapePnlCode;
    [SerializeField] private Text txtCode;
    [SerializeField] private int sizePortraitTxtCode;
    [SerializeField] private int sizeLandscapeTxtCode;

    private void Update()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        if (currentAspect >= 1.0f)
        {
            pnlCode.sizeDelta = new Vector2(0, heightLandscapePnlCode);
            txtCode.fontSize = sizeLandscapeTxtCode;
        }
        else
        {
            pnlCode.sizeDelta = new Vector2(0, heightPortraitPnlCode);
            txtCode.fontSize = sizePortraitTxtCode;
        }
    }
}
