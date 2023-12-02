using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField]
    private AudioSource nightcall;
    [SerializeField]
    private Button potlacenizvuku;
    [SerializeField]
    private Sprite muted;
    [SerializeField]
    private Sprite unmuted;


    bool mute = false;

    void Start()
    {
        nightcall.Play();
    }

    public void ChangeMute()
    {
        if (mute == true)
        {
            mute = false;
            nightcall.Play();
            potlacenizvuku.image.sprite = unmuted;
        }
        else
        {
            mute = true;
            nightcall.Pause();
            potlacenizvuku.image.sprite = muted;
        }
    }
}
