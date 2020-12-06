using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Data")]
public class Data : ScriptableObject
{
    public Skill[] skill;
    public int skillSlot;

    public float moveSpeed;
    public float jumpForce;
}
