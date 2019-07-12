using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            GetComponentInParent<Player>().grounded = true;
            if(other.GetComponent<PlatformMover>() != null)
            {
                transform.parent.transform.parent = other.transform;
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            GetComponentInParent<Player>().grounded = false;
            transform.parent.transform.parent = null;
        }
    }
}
