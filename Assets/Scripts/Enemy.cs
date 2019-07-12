using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    Vector3 CurrentTarget;
    int i = 0;
    public List<Vector3> targets = new List<Vector3>();
    public int DamagePower;

    void Start()
    {
        CurrentTarget = targets[i]; // Ecco la mia prima destinazione
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.GetComponent<Player>() != null)
        {
            collision.other.GetComponent<Player>().Damage(DamagePower);
        }
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, Speed * Time.deltaTime); // Mi muovo verso la mia destinazione
        if (transform.position == CurrentTarget) // Quando arrivo a destinazione
        {
            if (i == (targets.Count - 1)) // Se era l'ultima destinazione
            {
                if(targets.Count > 2)
                {
                    targets.Reverse();
                }
                i = 0; // Torno alla prima
            }
            else i++; // Se non lo era allora passo alla prossima
            CurrentTarget = targets[i]; // Aggiorno la destinazione
        }
    }
}
