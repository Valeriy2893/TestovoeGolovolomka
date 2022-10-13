using UnityEngine;

public class ButtonAgain : MonoBehaviour
{
    public bool activeWin;
    public bool activeError;

    private WinConditions winConditions;

    private void Start()
    {
        winConditions = FindObjectOfType<WinConditions>();
    }

    public void PressButtonAgain()
    {
        winConditions.fourthTile.SetBool("Restart", true);
        winConditions.fifthTile.SetBool("Restart", true);
        winConditions.sixthTile.SetBool("Restart", true);


        if (activeWin)
        {
            GameObject.Find("ParentWin").transform.GetChild(0).gameObject.SetActive(false);
            activeWin = false;
        }
        else if (activeError)
        {
            GameObject.Find("ParentError").transform.GetChild(0).gameObject.SetActive(false);
            activeError = false;
        }

    }
}
