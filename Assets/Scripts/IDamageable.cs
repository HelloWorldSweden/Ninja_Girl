using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    //Interface has no implementation.
    //Every class that inherit from this interface, have to implement Damage method.
    int Health { get; set; }

    void Damage();
}
