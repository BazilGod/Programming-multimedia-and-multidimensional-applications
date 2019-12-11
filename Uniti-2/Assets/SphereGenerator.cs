using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<MeshRenderer>();
        minX = render.bounds.min.x;
        maxX = render.bounds.max.x;
        minZ = render.bounds.min.z;
        maxZ = render.bounds.max.z;
        newY = gameObject.transform.position.y + 15;
        colorsCount = colors.Length;
        colorSetter = 0;
    }
    private static Color[] colors =
    {
        Color.red,
        new Color(1, 0.5f, 0),
        Color.yellow,
        Color.green,
        Color.cyan,
        Color.blue,
        new Color(0.56f,0,1)
    };

    private int colorSetter;
    private int colorsCount;
    MeshRenderer render;
    float minX, minZ, maxX, maxZ, newX, newZ, newY;

    // Update is called once per frame
    void Update()
    {
        newX = Random.Range(minX, maxX);
        newZ = Random.Range(minZ, maxZ);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(newX, newY, newZ);
            cube.transform.GetComponent<Renderer>().material.color = colors[colorSetter++ % colorsCount];
            cube.AddComponent<Rigidbody>();
            cube.name = $"Cube{colorSetter}";
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3(newX, newY, newZ);
            sphere.transform.GetComponent<Renderer>().material.color = colors[colorSetter++ % colorsCount];
            sphere.AddComponent<Rigidbody>();
            sphere.name = $"Sphere{colorSetter}";
        }
    }
}
