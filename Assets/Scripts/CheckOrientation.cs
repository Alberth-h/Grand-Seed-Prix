using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOrientation : MonoBehaviour
{
    [SerializeField] private Vector3 scalePortrait;
    [SerializeField] private Vector3 scaleLandscape;

    private void Update()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        if (currentAspect >= 1.0f)
        {
            this.GetComponent<RectTransform>().localScale = scaleLandscape;
        }
        else
        {
            this.GetComponent<RectTransform>().localScale = scalePortrait;
        }
    }
}
