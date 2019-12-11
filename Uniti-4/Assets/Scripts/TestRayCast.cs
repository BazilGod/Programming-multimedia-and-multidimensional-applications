using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RayDistance = 10f;
        HittedItem = new RaycastHit();
    }
    public float RayDistance;
    public RaycastHit HittedItem;
    public GameObject LastHittedItem;
    // Update is called once per frame
    void Update()
    {
        HittedItem = new RaycastHit();
        if(Physics.Raycast(new Ray(transform.position, transform.forward), out HittedItem, RayDistance))
        {
            if (LastHittedItem == null)
            {
                print(HittedItem.collider.gameObject.name);
                LastHittedItem = HittedItem.collider.gameObject;
                LastHittedItem.GetComponent<MeshRenderer>().material.color = new Color(1, 0.3f, 0.3f);
            }
            else
            {
                if (LastHittedItem != HittedItem.collider.gameObject)
                {
                    LastHittedItem.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
                    LastHittedItem = null;
                    LastHittedItem = HittedItem.collider.gameObject;
                    LastHittedItem.GetComponent<MeshRenderer>().material.color = new Color(1, 0.3f, 0.3f);
                }
            }
        }
        else
        {
            if (LastHittedItem != null)
            {
                LastHittedItem.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
                LastHittedItem = null;
            }
        }

    }
}
