using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    private Animation anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animation>();
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(1);
        anim.Play("DoorOpening");
    }
}
