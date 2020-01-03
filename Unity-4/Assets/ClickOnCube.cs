using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        R = new System.Random();
        Force = 0f;
        CountForce = false;
    }
    private System.Random R;
    public float Force;
    private bool CountForce;
    // Update is called once per frame
    void Update()
    {
        Force += CountForce ? 3000 * Time.deltaTime : 0;
    }
    private void OnMouseDown()
    {
        CountForce = true;
    }
    private void OnMouseUp()
    {
        transform.GetComponent<Rigidbody>().AddForce(R.Next((int)-Force, (int)Force), R.Next((int)-Force, (int)Force), R.Next((int)-Force, (int)Force));
        Force = 0f;
        CountForce = false;
        transform.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value, 1);
    }
}
