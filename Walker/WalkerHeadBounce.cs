using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerHeadBounce : MonoBehaviour
{

    [SerializeField]
    private Transform body;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(body.transform.position.x, (body.transform.position.y), body.transform.position.z);
    }
}
