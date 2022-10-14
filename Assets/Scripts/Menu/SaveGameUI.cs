using UnityEngine;

public class SaveGameUI : MonoBehaviour
{
    public float audioSourceVolume;

    public MenuManager menuManager;

    public string dataUI;

    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstOpenUI", 0) == 1)
        {
            LoadUI();
        }
        
    }
    private void FindObject()
    {
        menuManager = FindObjectOfType<MenuManager>();

    }

    public void CollectInfoUI()
    {
        audioSourceVolume = menuManager.audioBackground.volume;

    }
    public void SetInfoUI()
    {
        menuManager.audioBackground.volume = audioSourceVolume;

    }

    public void SaveUI()
    {
        FindObject();
        CollectInfoUI();
        dataUI = JsonUtility.ToJson(this, true);

        PlayerPrefs.SetString("ParametersUI", dataUI);
        PlayerPrefs.SetInt("FirstOpenUI", 1);
    }

    public void LoadUI()
    { 
        FindObject();
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("ParametersUI"), this);
        Invoke("SetInfoUI", 0.1f);
    }

}
