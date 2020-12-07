using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCircle : Detection
{
    public override bool Detect()
    {
        return OverlapCircleDetect();
    }

    private bool OverlapCircleDetect()
    {
        Collider2D col = Physics2D.OverlapCircle(ai.transform.position, ai.detectRadius, ai.enemyLayer);

        if (!col)
            return false;
        else
            return true;
    }
}
