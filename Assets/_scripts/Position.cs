using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used only so we can see the gizmos in Unity when we build the alien squad.

public class Position : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,0.5f);
    }
}
