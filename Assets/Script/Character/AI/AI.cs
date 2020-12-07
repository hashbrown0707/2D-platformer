using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : Character
{
    public Detection[] detections;
    public Action[] actions;


    public float detectRadius;
    public LayerMask enemyLayer;     //can be anything ex: player, another enemy or object

    private void Update()
    {
        DoDetect();
    }

    private void DoDetect()
    {
        foreach(Detection d in detections)
        {
            d.GetCurAI(this);

        }
    }
}
