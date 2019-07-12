using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().Damage(1);
            Camera.main.transform.parent = null;
        }
    }
}
