using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action")]
public abstract class Action : AIBehaviorBase
{
    public abstract void Act();
}
