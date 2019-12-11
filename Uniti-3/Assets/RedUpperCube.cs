using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedUpperCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(Vector3.up, 15);
    }
    private void OnCollisionEnter(Collision collision)
    {
   
     if(collision.gameObject.tag!="floor")
        Destroy(collision.gameObject);
    }
}
