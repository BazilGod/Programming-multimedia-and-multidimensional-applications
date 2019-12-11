using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision myCollision)
    {
        if(myCollision.gameObject.name == "floor")
        {
            Debug.Log("It's floor.");
        }
        else if (myCollision.gameObject.name == "wall1")
        {
            Debug.Log("It's wall1");
        }
        else if (myCollision.gameObject.name == "wall2")
        {
            Debug.Log("It's wall2");
        }
    }
}
