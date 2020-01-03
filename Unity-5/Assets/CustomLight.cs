using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLight : MonoBehaviour
{
    void Start()
    {
        Light[] lights = GameObject.FindObjectsOfType<Light>();
        foreach (var item in lights)
        {
            item.range = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Light>().range = 15;
    }

    private void OnTriggerExit(Collider other)
    {
        this.gameObject.GetComponent<Light>().range = 0;
    }

}
