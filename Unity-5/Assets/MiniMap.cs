using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour
{

    public Transform target;
    public float zoom = 10;

    private Vector2 XRot = Vector2.right;
    private Vector2 YRot = Vector2.up;

    public Vector2 TransformPosition(Vector3 position)
    {
        Vector3 offset = position - target.position;
        Vector2 pos = offset.x * XRot;
        pos += offset.z * YRot;
        pos *= zoom;
        return pos;
    }

    public Vector3 TransformRotation(Vector3 rotation)
    {
        return new Vector3(0, 0, target.eulerAngles.y - rotation.y);
    }

    public Vector2 MoveInside(Vector2 point)
    {
        Rect rect = GetComponent<RectTransform>().rect;
        point = Vector2.Max(point, rect.min);
        point = Vector2.Min(point, rect.max);
        return point;
    }

    void LateUpdate()
    {
        XRot = new Vector2(target.right.x, -target.right.z);
        YRot = new Vector2(-target.forward.x, target.forward.z);
    }
}