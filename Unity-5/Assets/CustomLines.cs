using System;
using UnityEngine;
using System.Collections;

public class CustomLines : MonoBehaviour
{
    public Camera _camera;
    public Rigidbody projectile;

    public float speed = 20f;
    // Use this for initialization
    void Start()
    {
        //_camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

          
                Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                               _camera.transform.position,
                                                               _camera.transform.rotation)
                    as Rigidbody;

            instantiatedProjectile.velocity = _camera.velocity; //transform.TransformDirection(new Vector3(0, 0, speed));
            instantiatedProjectile.position = _camera.transform.position;//transform.TransformDirection(new Vector3(0, 0, speed));


        }
    }

    private IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;

        Debug.Log("Sphere");
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
