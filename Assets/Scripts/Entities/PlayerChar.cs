using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : MonoBehaviour, ICharacter
{
    public int health { get; set; }

    public void Initialize()
    {
        health = 100;
    }

    public void TakeDamage(int rawDam)
    {
        health -= rawDam;
    }

}
