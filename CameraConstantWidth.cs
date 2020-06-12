using UnityEngine;

public class CameraConstantWidth : MonoBehaviour
{
    public Vector2 DefaultResolution = new Vector2(1280, 720);
    [Range(0f, 1f)] public float WidthOrHeight = 0;

    private Camera componentCamera;

    private float initialSize;
    private float targetAspect;

    public Transform target;
    public Vector3 offset;

    private float leftScreenEdge = 0;
    private float rightScreenEdge = 0;
    private float topScreenEdge = 15;
    private float bottomScreenEdge = -15;

    private void Start()
    {
        componentCamera = GetComponent<Camera>();
        initialSize = componentCamera.orthographicSize;
        targetAspect = DefaultResolution.x / DefaultResolution.y;
    }

    private void FixedUpdate()
    {
        float constantWidthSize = initialSize * (targetAspect / componentCamera.aspect);
        componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, initialSize, WidthOrHeight);
        transform.position = target.position + offset;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftScreenEdge, rightScreenEdge),
                                        Mathf.Clamp(transform.position.y, bottomScreenEdge, topScreenEdge),
                                        transform.position.z);
    }

    private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;
        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);
        return vFovInRads * Mathf.Rad2Deg;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftScreenEdge, topScreenEdge), new Vector2(rightScreenEdge, topScreenEdge));
        Gizmos.DrawLine(new Vector2(leftScreenEdge, bottomScreenEdge), new Vector2(rightScreenEdge, bottomScreenEdge));
        Gizmos.DrawLine(new Vector2(leftScreenEdge, topScreenEdge), new Vector2(leftScreenEdge, bottomScreenEdge));
        Gizmos.DrawLine(new Vector2(rightScreenEdge, topScreenEdge), new Vector2(rightScreenEdge, bottomScreenEdge));
    }
}