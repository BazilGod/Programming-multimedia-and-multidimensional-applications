using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_patam : MonoBehaviour
{
    public GameObject player;
    public float FollowingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        FollowingSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, FollowingSpeed * Time.deltaTime);
    }
}
