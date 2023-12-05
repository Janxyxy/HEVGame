using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{
    [SerializeField]
    private AudioSource nightcall;
    [SerializeField]
    private Button potlacenizvuku;
    [SerializeField]
    private Sprite muted;
    [SerializeField]
    private Sprite unmuted;
    [SerializeField]
    private GameObject win;
    [SerializeField]
    private GameObject loading;
    [SerializeField]
    private GameObject downloadbutton;
    [SerializeField]
    private GameObject playbutton;
    [SerializeField]
    private GameObject levltext;
    [SerializeField]
    private TextMeshProUGUI levltexttext;
    [SerializeField]
    private GameObject cilhry;
    [SerializeField]
    private TextMeshProUGUI seberkanistry;
    [SerializeField]
    private AudioSource vroom;
    [SerializeField]
    private AudioSource vyhra;


    bool mute = false;
   

    void Start()
    {
        NulaKanistru();
        cilhry.SetActive(false);
;       playbutton.SetActive(false);
        nightcall.Play();
        win.SetActive(false);
        win.SetActive(false);
        levltext.SetActive(false);

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

    public void Exit()
    {
        Application.Quit();
    }

    public void HideLoading()
    {
        cilhry.SetActive (true);
        levltext.SetActive(true);
        playbutton.SetActive(true);

        loading.SetActive(false);
        downloadbutton.SetActive(false);
        win.SetActive(false);
      
    }

    public void ShowWin()
    {
        win.SetActive(true);
        downloadbutton.SetActive(true);

        playbutton.SetActive(false);
        levltext.SetActive(false);
        cilhry.SetActive(false);
    }

    public void Hideplay()
    {
        playbutton.SetActive(false);
    }

    public void Showplay()
    {
        playbutton.SetActive(true);
    }
    public void ChangeLevel(int level)
    {
        level++;
        levltexttext.text = "Levl " + level.ToString();
    }

    public void NulaKanistru()
    {
        seberkanistry.text = "Seber kanystr (0/1)";
        seberkanistry.color = Color.red;
    }

    public void VsechnyKanistry()
    {
        seberkanistry.text = "Seber kanystr (1/1)";
        seberkanistry.color = Color.green;
    }

    public void VroomPlay()
    {
        vroom.Play();
    }
    public void VrooStop()
    {
        vroom.Pause();
    }
    public void Vyhra()
    {
        vyhra.Play();   
    }

}
