using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Camera camera;
    public List<PlayerChar> myPlayerChars;
    public PlayerChar myPlayerCharSelected;
    public PlayerChar UI_characterSelected;
    public Canvas myUICanvas;
    public bool UIOpen = false;

    private EventSystem eventSystem;

    void Start()
    {
        //myUICanvas = GetComponent<Canvas>();
        //camera = GetComponent<Camera>();
        eventSystem = GetComponent<EventSystem>();

    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UIOpen)
        {
            OnClick();
            Debug.Log("Mouse Clicked");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Pan();
        }
    }

    //Raycast into scene checking for player trying to move
    void OnClick()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
          
            // Do something with the object that was hit by the raycast.
            Debug.Log("object hit = " + hit.collider.gameObject.name as string);

            ObjectCheck(hit.collider.gameObject);

        }
    }

    void Pan()
    {
        Debug.Log("Right Clicked");
    }

    //check and return the object type hit by the raycast
    void ObjectCheck(GameObject objectHitByRayCast)
    {
        //check if object clicked is a tile
        //if (objectHitByRayCast.CompareTag("Tile"))
        //{
        //    MoveCharacter(objectHitByRayCast);
        //}

        //check if the object clicked is a player's character
        if (objectHitByRayCast.CompareTag("PlayerCharacter"))
        {

            myPlayerCharSelected = objectHitByRayCast;
            PlayerCharacterSelected(objectHitByRayCast);
        }
    }

    void PlayerCharacterSelected(GameObject PC_Selected)
    {
        Debug.Log("PlayerCharSelected Method Entered");

        //Highlight selected character
        PC_Selected.GetComponent<PlayerCharacter_S>().Highlight();
        PC_Selected = myPlayerCharSelected;

        //Create and draw UI menu, set reference to this PC for dehighlighting
        GameObject my_UI_characterSelected = Instantiate(UI_characterSelected);
        my_UI_characterSelected.transform.SetParent(myUICanvas.transform, true);

        

        my_UI_characterSelected.SetActive(true);
        UIOpen = true;
    }



}