using UnityEngine;

public class WinConditions : MonoBehaviour
{
    public Animator fourthTile;
    public Animator fifthTile;
    public Animator sixthTile;


    private void Start()
    {
        fourthTile = GameObject.Find("4").GetComponent<Animator>();
        fifthTile = GameObject.Find("5").GetComponent<Animator>();
        sixthTile = GameObject.Find("6").GetComponent<Animator>();

    }

    public void AnimationTiles()
    {
        fourthTile.SetTrigger("Win");
        fifthTile.SetTrigger("Win");
        sixthTile.SetTrigger("Win");

        Invoke("ActivePanelWin", 1f);

        fourthTile.SetBool("Restart", false);
        fifthTile.SetBool("Restart", false);
        sixthTile.SetBool("Restart", false);

    }


    private void ActivePanelWin()
    {
        GameObject.Find("ParentWin").transform.GetChild(0).gameObject.SetActive(true);
    }


}
