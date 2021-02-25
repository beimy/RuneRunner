using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    void Initialize();
    int health { get; set; }
    void TakeDamage(int rawDam);
    

}
