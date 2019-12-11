using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_position : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        float posZ = transform.position.z;

        transform.position = new Vector3(posX + speed, posY, posZ);
    }
}
