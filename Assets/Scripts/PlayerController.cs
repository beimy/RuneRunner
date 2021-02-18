using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Camera camera;
    public List<GameObject> myPlayerChars;
    public GameObject myPlayerCharSelected;
    public GameObject UI_characterSelected;
    public Canvas myUICanvas;


    private EventSystem eventSystem;



   
    void Start()
    {
        //myUICanvas = GetComponent<Canvas>();
        //camera = GetComponent<Camera>();
        eventSystem = GetComponent<EventSystem>();

    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

            //MoveCharacter(hit.collider.gameObject);
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
            //Color oldColor =  objectHitByRayCast.GetComponent<Renderer>().material.color;
            //objectHitByRayCast.GetComponent<Renderer>().material.color = Color.green;

            myPlayerCharSelected = objectHitByRayCast;
            PlayerCharacterSelected(objectHitByRayCast);
        }
    }

    void PlayerCharacterSelected(GameObject PC_Selected)
    {
        Debug.Log("PlayerCharSelected Method Entered");

        //Highlight selected character
        PC_Selected.GetComponent<PlayerCharacter_S>().Highlight();

        //Create and draw UI menu, set reference to this PC for dehighlighting
        GameObject my_UI_characterSelected = Instantiate(UI_characterSelected);
        my_UI_characterSelected.transform.SetParent(myUICanvas.transform, true);
        my_UI_characterSelected.GetComponent<CloseUIElement>().myPC = PC_Selected;


        my_UI_characterSelected.SetActive(true);
    }

    //Move player's character to a new tile
    public void MoveCharacter(GameObject tileHit)
    {
       //myPlayerCharSelected.transform.position = ((tileHit.transform.position + new Vector3(0, 1, 0)));

    }

    public void MoveOptionSelected()
    {

    }



}