using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xInput;
    private float yInput;
    private Rigidbody myRB;
    private Animator myAnimator;
    private bool isDead;
    public bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");

            myRB.velocity = new Vector3(xInput, 0, yInput);

            if (xInput != 0 && yInput != 0)
            {
                Vector2 moveDirection = new Vector2(xInput, yInput);
                float theta = Mathf.Asin(xInput / moveDirection.magnitude) * 180 / Mathf.PI;
                if (yInput >= 0)
                {
                    gameObject.transform.eulerAngles = new Vector3(0f, theta, 0f);
                }
                else
                {
                    gameObject.transform.eulerAngles = new Vector3(0f, -theta + 180f, 0f);
                }
            }
        }

        if (myRB.velocity.magnitude > 0.1)
        {
            myAnimator.SetBool("IsMoving", true);

        }
        else
        {
            myAnimator.SetBool("IsMoving", false);
        }

        if (test)
        {
            Die();
            test = false;
        }
    }

    public void Die()
    {
        myAnimator.SetBool("IsDead", true);
        isDead = true;
    }
}
