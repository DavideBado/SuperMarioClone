using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.GetComponent<Player>() != null)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
