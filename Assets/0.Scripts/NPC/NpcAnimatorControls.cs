using UnityEngine;

public class NpcAnimatorControls : MonoBehaviour
{
    public Agent npc;
    
    public void AnimationEnd()
    {
        npc.AnimationEnd();
    }
    
}
