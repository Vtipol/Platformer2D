using UnityEngine;
using System;

public class BaseEntityLine : MonoBehaviour
{
    public event Action OnLineUpdate;
    [Header("Line Settings")]
    public LineRenderer lineRenderer;
    public bool loop = false;
    private Vector2[] points;
    void Start()
    {
        lineRenderer.gameObject.SetActive(false);
        UpdateLineRenderer();
    }

    public Vector2 GetPoint(int index){
        return points[index];
    }

    public Vector2[] GetPoints(){
        return points;
    }

    public int GetPointCount(){
        return points.Length;
    }

    private void UpdateLineRenderer()
    {
        points = new Vector2[transform.childCount];
        int j = 0;

        foreach(Transform child in transform){
            points[j] = child.position;
            j++;
        }

        if (points.Length < 2)
        {
            Debug.LogWarning("GameEntityLine requires at least 2 points!");
            return;
        }

        for (int i = 0; i < points.Length - 1; i++)
        {
            LineRenderer newLine = Instantiate(lineRenderer);
            newLine.enabled = true;

            newLine.positionCount = 2;
            MakeLine(points[i], points[i+1]);
        }

        if(loop){
            MakeLine(points[0], points[points.Length-1]);
        }

        OnLineUpdate?.Invoke();
    }

    private void MakeLine(Vector2 pos1, Vector2 pos2){
        LineRenderer newLine = Instantiate(lineRenderer.gameObject).GetComponent<LineRenderer>();
            newLine.gameObject.SetActive(true);
            newLine.useWorldSpace = true;

            newLine.positionCount = 2;
            newLine.SetPosition(0, pos1);
            newLine.SetPosition(1, pos2);
    }

    private void OnDrawGizmos()
    {
        int childCount = transform.childCount;
        if (childCount < 2) return;

        Gizmos.color = Color.cyan;

        for (int i = 0; i < childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        if (loop)
        {
            Gizmos.DrawLine(transform.GetChild(childCount - 1).position, transform.GetChild(0).position);
        }
    }
}
