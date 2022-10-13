using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image tile;
    private Vector2 scaleTile;
    private Vector3 tilePosition;
    private RaycastHit raycastHit;

    private ButtonAgain buttonAgain;
    private SaveGame saveGame;

    private void Awake()
    {
        tile = GetComponent<Image>();

        buttonAgain = FindObjectOfType<ButtonAgain>();
        saveGame = FindObjectOfType<SaveGame>();
    }
    private void Start()
    {
        scaleTile = tile.rectTransform.localScale;

        Invoke("SaveTilePosition", 0.2f);

    }
    private void SaveTilePosition()
    {
        tilePosition = GetComponent<RectTransform>().position;

        saveGame.Save();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;


    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 changeScale = new Vector2(1.1f, 1.1f);

        tile.rectTransform.localScale = changeScale;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        tile.rectTransform.localScale = scaleTile;

        Ray();

    }

    private void Ray()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out raycastHit))
        {
            DetectedObject();
        }
        else
        {
            GetComponent<RectTransform>().position = tilePosition;
        }

    }
    private void DetectedObject()
    {
        WinConditions winConditions = raycastHit.collider.gameObject.GetComponent<WinConditions>();
        Pockets pockets = raycastHit.collider.gameObject.GetComponent<Pockets>();

        if (winConditions)
        {
            buttonAgain.activeWin = true;

            raycastHit.collider.gameObject.GetComponent<Image>().color = Color.black;

            GetComponent<RectTransform>().position = tilePosition;

            winConditions.AnimationTiles();


        }
        else if (pockets)
        {
            GetComponent<RectTransform>().position = pockets.transform.position;
            SaveTilePosition();
        }

        else
        {
            GetComponent<RectTransform>().position = tilePosition;

            GameObject.Find("ParentError").transform.GetChild(0).gameObject.SetActive(true);
            buttonAgain.activeError = true;
        }
    }
    

}
