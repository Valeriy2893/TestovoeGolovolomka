using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public Vector3 tilePositions;

    public GameObject dragAndDrop;

    public string data;

    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstOpen", 0) == 1)
        {
            Load();
        }

    }
    private void FindObject()
    {

        dragAndDrop = FindObjectOfType<DragAndDrop>().gameObject;

    }


    public void CollectInfo()
    {

        tilePositions = dragAndDrop.transform.position;

    }
    public void SetInfo()
    {

        dragAndDrop.transform.position = tilePositions;
    }

    public void Save()
    {
        FindObject();
        CollectInfo();
        data = JsonUtility.ToJson(this, true);

        PlayerPrefs.SetString("Parameters", data);
        PlayerPrefs.SetInt("FirstOpen", 1);

    }

    public void Load()
    {
        Invoke("FindObject", 0.1f);
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("Parameters"), this);
        Invoke("SetInfo", 0.1f);
    }

}
