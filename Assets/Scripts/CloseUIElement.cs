using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUIElement : MonoBehaviour
{
    public GameObject myPC;

    public void CloseMe()
    {
        Debug.Log("Close Me Ran");

        myPC.GetComponent<PlayerCharacter_S>().DeHighlight();

        Destroy(gameObject);
    }
}
