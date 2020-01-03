using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRayCast : MonoBehaviour
{

    private Camera _camera;

    // Use this for initialization
    void Start ()
  {
      _camera = GetComponent<Camera>();
  }
    // Start is called before the first frame update
  
 private IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        yield return new WaitForEndOfFrame();
        Destroy(sphere);
    }

    void Update ()
{
     Vector3 forward = transform.TransformDirection(Vector3.forward) * 20;
        Debug.DrawRay(transform.position, forward, Color.green);
    if (Input.GetMouseButton(0) )
    {  var n = 0;
        var centerPoint = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight /2, 0);
        Ray ray = _camera.ScreenPointToRay(centerPoint);
        RaycastHit hit;
        bool e = Physics.Raycast(ray, out hit);
        StartCoroutine(SphereIndicator(hit.point));
    
    }
}
}
