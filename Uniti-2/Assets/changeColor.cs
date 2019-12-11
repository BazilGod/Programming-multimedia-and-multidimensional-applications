using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    void Start()
    {
        colorSetter = 0;
        colorsCount = colors.Length;
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.GetComponent<Renderer>().material.color = colors[colorSetter++ % colorsCount];
            colorSetter = colorSetter == int.MaxValue - 1 ? 0 : colorSetter;
        }
    }
}


