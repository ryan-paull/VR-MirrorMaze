using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement : MonoBehaviour
{
    private ChaserScript myChaserScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject chaser = GameObject.Find("ChaserHolder");
        myChaserScript = chaser.GetComponent<ChaserScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.gameObject.name == "PlayerHolder")
        {
            myChaserScript.savedLocations.Add(gameObject);
            Debug.Log(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "ChaserHolder")
        {
            if (myChaserScript.savedLocations.Count > 0)
            {
                if (myChaserScript.savedLocations[0] == gameObject)
                {
                    myChaserScript.savedLocations.Remove(gameObject);
                    Debug.Log(gameObject);
                }
            }
        }
    }
}
