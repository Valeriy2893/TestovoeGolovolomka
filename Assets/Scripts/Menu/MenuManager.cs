using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject dontDestroy;

    public AudioSource audioBackground;

    private Slider sliderVolume;
    private Text textVolume;

    private GameObject panelVolume;

    private SaveGameUI saveGameUI;

    private void Start()
    {
        audioBackground = GameObject.Find("ButtonVolume").GetComponent<AudioSource>();
       
        DontDestroyOnLoad(dontDestroy);

        saveGameUI = FindObjectOfType<SaveGameUI>();
    }

    public void PressButton()
    {
        panelVolume = GameObject.Find("ButtonVolume").transform.GetChild(0).gameObject;
        panelVolume.SetActive(true);

        sliderVolume = GameObject.Find("PanelVolume").transform.GetChild(0).gameObject.GetComponent<Slider>();

        textVolume = GameObject.Find("TextVolume").GetComponent<Text>();

        sliderVolume.value = audioBackground.volume;
        textVolume.text = $"Звук: {Math.Round(sliderVolume.value * 100, 0)}%";

        saveGameUI.SaveUI();
    }

    public void ChangeVolume()
    {
        audioBackground.volume = sliderVolume.value;

        textVolume.text = $"Звук: {Math.Round(sliderVolume.value * 100, 0)}%";
    }
    public void ExitPanelVolume()
    {
        panelVolume = GameObject.Find("ButtonVolume").transform.GetChild(0).gameObject;
        panelVolume.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("PanelStartGame").gameObject.SetActive(false);
    }
}
