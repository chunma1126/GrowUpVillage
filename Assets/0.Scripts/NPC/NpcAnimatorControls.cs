using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimatorControls : MonoBehaviour
{
    public Npc npc;

    public void AnimationEnd()
    {
        npc.AnimationEnd();
    }
    
}
