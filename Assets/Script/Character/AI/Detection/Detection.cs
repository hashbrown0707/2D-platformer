using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Detection")]
public abstract class Detection : AIBehaviorBase
{
    public abstract bool Detect();
}
