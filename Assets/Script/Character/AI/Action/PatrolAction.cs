using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : Action
{
    public override void Act()
    {
        Patrol();
    }

    private void Patrol()
    {
        Debug.Log("Patrol");
    }
}
