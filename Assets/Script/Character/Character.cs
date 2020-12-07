using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public Data data;


    protected bool canMove = true;

    public void TakeDamage(Character source)
    {
        data.curHealth -= source.data.damage;

        if (data.curHealth <= 0)
            Die();
    }

    public virtual void Die()   //player die differently
    {

    }


    protected IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
}
