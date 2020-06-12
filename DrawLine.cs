using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    public GameObject linePrefab;
    private GameObject currentLine;

    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private Vector2[] arr = new Vector2[2];


    void Start() {

    }


    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (lineRenderer == null) {
                CreateLine();
            }

            arr[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, arr[0]);
            lineRenderer.SetPosition(1, arr[0]);

        }
        else if (Input.GetMouseButtonUp(0) && lineRenderer) {
            arr[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(1, arr[1]);
            if (Vector3.Distance(arr[0], arr[1]) > 5) {

            }
            lineRenderer.SetPosition(1, arr[1]);
            edgeCollider.points = arr;
        }
        else if (Input.GetMouseButton(0) && lineRenderer) {
            arr[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(1, arr[1]);
        }
    }

    void CreateLine() {
        Destroy(lineRenderer);
        currentLine = Instantiate(linePrefab, Vector2.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
    }
}
