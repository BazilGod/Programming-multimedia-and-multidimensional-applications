using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountOfLightsCust : MonoBehaviour
{
    public static int countEnemies = 0;
    public Text numericalScore;


    // Update is called once per frame
    void Update()
    {
        numericalScore.GetComponent<UnityEngine.UI.Text>().text = countEnemies.ToString();
    }
}
