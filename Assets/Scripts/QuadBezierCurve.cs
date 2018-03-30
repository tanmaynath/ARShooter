using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadBezierCurve : MonoBehaviour {

    public int numPoints=30;
    Vector3[] positions = new Vector3[30];
    public Transform point0, point1, point2, cube;
    public LineRenderer lineRenderer;
    public float speed;


	// Use this for initialization
	void Start () {
        Debug.Log(point0.position + "  " + point1.position + "  " + point2.position);
        lineRenderer.positionCount = numPoints;


	}
	
	// Update is called once per frame
	void Update () {
        FindPointOnCurve();

        MoveAlongCurve();
	}

    void FindPointOnCurve()
    {
        for (int i = 1; i < numPoints + 1;i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalcQuadBezierCurve(t, point0.position, point1.position, point2.position);
            Debug.Log("position: " + positions[i-1]);
        }
        lineRenderer.SetPositions(positions);

    }

    Vector3 CalcQuadBezierCurve(float t, Vector3 P0, Vector3 P1, Vector3 P2)
    {
        // (1-t)^2 * P0 + 2(1-t)P1 + t^2 * P2

        float u = 1.0f - t;
        float uu = u * u;
        float tt = t * t;
        Vector3 p = uu * P0;
        p += 2 * u * t * P1;
        p += tt * P2;
        return p;

    }

    void MoveAlongCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            cube.position = Vector3.Lerp(cube.position, positions[i - 1], Time.deltaTime * speed);
            //Debug.Log(cube.position + "  " + positions[i-1]);
        }
    }
}
