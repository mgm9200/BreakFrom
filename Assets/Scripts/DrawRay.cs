using UnityEngine;
using System.Collections;

public class DrawRay : MonoBehaviour {

    public float ray;
    public bool Show;
    public Vector3 direction;
    public Color color;

    void OnDrawGizmosSelected()
    {
        if (Show)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(transform.position, transform.position + direction * ray);
        }
    }
}
