using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TMP_Text CoinsText;
    private int life = 1;
    public float WalkSpeed, JumpForce;
    public KeyCode Left, Right, Up, Down;
    private KeyCode previousHorizontalKey;
    public bool grounded;
    private Rigidbody rb;
    public int Coins = 0;
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        UpdateUI();
    }

    private void CheckInput()
    {
        if(Input.GetKey(Left))
        {
            if(grounded)
            {
                previousHorizontalKey = Left;
            }
            if (grounded || previousHorizontalKey == Left)
            {
                transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime); 
            }
            else
            {
                transform.Translate(Vector3.left * WalkSpeed / 2 * Time.deltaTime); 
            }
        }
        if (Input.GetKey(Right))
        {
            if (grounded)
            {
                previousHorizontalKey = Right;
            }
            if (grounded || previousHorizontalKey == Right)
            {
                transform.Translate(Vector3.right * WalkSpeed * Time.deltaTime); 
            }
            else
            {
                transform.Translate(Vector3.right * WalkSpeed / 2 * Time.deltaTime);
            }
        }
        if (Input.GetKey(Up) && grounded)
        {
            rb.AddForce(Vector3.up * JumpForce);
            //transform.Translate(Vector3.up * JumpForce * Time.deltaTime);
        }
        if (Input.GetKey(Down))
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }

        if(Input.GetKeyUp(previousHorizontalKey))
        {
            previousHorizontalKey = KeyCode.Escape;
        }
    }   

    public void Damage(int _amount)
    {
        life -= _amount;
        if(life <= 0)
        {
            //Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
    }

    private void UpdateUI()
    {
        CoinsText.text = ("Coins: " + Coins.ToString());
    }
}
