using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Camera camera;
    public List<GameObject> myPlayerChars;
    public GameObject myPlayerCharSelected;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
        if (objectHitByRayCast.CompareTag("Tile"))
        {
            MoveCharacter(objectHitByRayCast);
        }

        //check if the object clicked is a player's character
        if (objectHitByRayCast.CompareTag("PlayerCharacter"))
        {
            //Color oldColor =  objectHitByRayCast.GetComponent<Renderer>().material.color;
            //objectHitByRayCast.GetComponent<Renderer>().material.color = Color.green;

            PlayerCharacterSelected();
        }
    }

    void PlayerCharacterSelected()
    {
        GameObject UI_characterHighlighted = Instantiate(Charact, )
    }

    //Move player's character to a new tile
    public void MoveCharacter(GameObject tileHit)
    {
        myPlayerCharSelected.transform.position = ((tileHit.transform.position + new Vector3(0, 1, 0)));
    }

    public void MoveOptionSelected()
    {

    }



}
