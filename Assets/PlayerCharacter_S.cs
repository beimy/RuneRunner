using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter_S : MonoBehaviour
{

   public Material myMaterial1;
   public Material myMaterial2;

    

    public void Highlight()
    {
        Debug.Log("Highlight entered");

        GetComponent<Renderer>().material = myMaterial2;
    }

    public void DeHighlight()
    {
        GetComponent<Renderer>().material = myMaterial1;
    }
}
