using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenUpperCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    Cursor MyCursor;
    // Update is called once per frame
    void Update()
    {
   
    }
    void OnCollisionEnter(Collision collision)
    {
    	if(collision.gameObject.tag=="enemy")
    	{
    		
        collision.gameObject.GetComponent<Rigidbody>().AddForce(0,300,0);
    	}

         else if (collision.gameObject.tag=="barrier")
         {
         	Destroy(collision.gameObject);
         }
       
    }
}
