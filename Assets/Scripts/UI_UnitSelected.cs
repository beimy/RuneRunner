using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_UnitSelected
{
    public GameObject myUnit;
    PlayerController myPlayerController;

    private EventSystem eventSystem;
    private Camera camera;

    UI_UnitSelected(GameObject _myUnit)
    {
        _myUnit = myUnit;
        myPlayerController = myUnit.GetComponent<PlayerController>();
    }

    public void MoveMyUnit(GameObject myUnit)
    {
        myUnit = GetComponent<PlayerController>().myPlayerCharSelected;
        Camera myCamera = myPlayerController.camera;
        RaycastHit hit;
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        gameObject.SetActive(false);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            // Do something with the object that was hit by the raycast.
            Debug.Log("object hit = " + hit.collider.gameObject.name as string);
            if(objectHit.gameObject.layer == 8)
            {
                myUnit.transform.position = ((objectHit.transform.position + new Vector3(0, 1, 0)));
               // CloseMe();
            }
        }
    }


    public void CloseMe()
    {
        Debug.Log("Close Me Ran");

        myUnit.GetComponent<PlayerCharacter_S>().DeHighlight();
        myPlayerController.UIOpen = false;

        Destroy(gameObject);
    }

}
