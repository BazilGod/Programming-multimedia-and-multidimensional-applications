using UnityEngine;
using System.Collections;

public class Blip : MonoBehaviour
{

    public Transform target;
    public bool inBounds;
    public float minScale = 1;

    private RectTransform rect;
    private MiniMap map;

    void Start()
    {
        map = GetComponentInParent<MiniMap>();
        rect = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        Vector2 pos = map.TransformPosition(target.position);
        if (inBounds) pos = map.MoveInside(pos);
        float scale = Mathf.Max(minScale, map.zoom);
        rect.localScale = new Vector3(scale, scale, 1);
        rect.localEulerAngles = map.TransformRotation(target.eulerAngles);
        rect.localPosition = pos;
    }
}