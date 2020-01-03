using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string t = Application.dataPath;
        t = t + "/map.png".ToString();
        ScreenCapture.CaptureScreenshot(t.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
