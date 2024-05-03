using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    public List<GameObject> savedLocations = new List<GameObject>();

    private Vector3 directionMove;
    private Rigidbody myRB;
    private float countdown;
    private Animator myAnimator;
    private GameObject player;
    private PlayerMovement myPlayerMovement;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        GameObject parentStart = GameObject.Find("D");
        GameObject elementStart = parentStart.transform.Find("2").gameObject;
        gameObject.transform.position = elementStart.transform.position;
        Debug.Log(elementStart.transform.position.ToString());
        myRB = GetComponent<Rigidbody>();
        countdown = Time.time + 1f;
        myAnimator = GetComponentInChildren<Animator>();
        player = GameObject.Find("PlayerHolder");
        myPlayerMovement = player.GetComponentInChildren<PlayerMovement>();
        //isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > countdown && savedLocations.Count != 0)
        {
            directionMove = savedLocations[0].transform.position - transform.position;
            directionMove = new Vector3(directionMove.x, 0f, directionMove.z).normalized;
            myRB.velocity = new Vector3(directionMove.x, myRB.velocity.y, directionMove.z);

            float theta = Mathf.Asin(directionMove.x / directionMove.magnitude) * 180 / Mathf.PI;
            if (directionMove.z >= 0)
            {
                gameObject.transform.eulerAngles = new Vector3(0f, theta, 0f);
            }
            else
            {
                gameObject.transform.eulerAngles = new Vector3(0f, -theta + 180f, 0f);
            } 
        }

        if (savedLocations.Count == 0)
        {
            transform.LookAt(player.transform);
            myAnimator.SetBool("IsAttack", true);
            myPlayerMovement.Die();
        }
    }
}
