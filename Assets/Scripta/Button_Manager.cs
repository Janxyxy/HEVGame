using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Manager : MonoBehaviour
{
    public void HideCanvas(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
        Debug.Log("I drive");
    }
}