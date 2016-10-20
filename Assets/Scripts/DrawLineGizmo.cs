using UnityEngine;
using System.Collections;

public class DrawLineGizmo : MonoBehaviour {

    public float ray;
    public Transform facing;
    public bool Show;
    public Vector3 direction;
    public Color color;

    void OnDrawGizmosSelected()
    {
        if (Show)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(transform.position, transform.position + direction * ray * facing.localScale.x);
        }
    }
}
