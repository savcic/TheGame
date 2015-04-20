using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	// Use this for initialization
	void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,1);
    }
}
