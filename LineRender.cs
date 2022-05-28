using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private Camera cam;
    public GameObject drawingPrefab;

    private List<Vector3> pointsForDraw = new List<Vector3>();
    private List<Vector2> pointsForEdge = new List<Vector2>();

    [SerializeField]    public GameObject burn;




    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        cam = Camera.main;

    }


    void Update()
    {
        if(Input.GetButtonDown("Fire1") && PauseMenu.GameIsPaused == false)
        {
            DrawLine();
        }
    }

    private void DrawLine()
    {

        if(pointsForDraw.Count < 2)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 converted = cam.ScreenToWorldPoint(mousePos);
            converted.z = 0;
           
            pointsForDraw.Add(converted);
            pointsForEdge.Add(converted);
            
            lineRenderer.positionCount = pointsForDraw.Count;
            lineRenderer.SetPositions(pointsForDraw.ToArray());

            edgeCollider.points = pointsForEdge.ToArray();
        }
        
    }

}