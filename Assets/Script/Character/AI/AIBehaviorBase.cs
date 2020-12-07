using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviorBase : ScriptableObject
{
    protected AI ai { get; private set; }

    public void GetCurAI(AI ai)
    {
        this.ai = ai;
    }
}
