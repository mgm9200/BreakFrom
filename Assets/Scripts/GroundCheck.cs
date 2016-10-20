using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    public Transform character;
    public float offSetX = -.3f;
    public float offSetY = 0f;
    public float sizeX = .3f;
    public float sizeY = .3f;
    public bool show = true;

    public LayerMask WhatIsGround;

    void FixedUpdate()
    {
        bool Grounded = Physics2D.BoxCast(new Vector3(character.transform.position.x + offSetX, character.transform.position.y + offSetY, 0), new Vector2(sizeX, sizeY), transform.eulerAngles.z, Vector2.down, 0f, WhatIsGround);
        Debug.Log(Grounded);
    }

    void OnDrawGizmos()
    {
        if (show)
        Gizmos.DrawCube(new Vector3(character.transform.position.x + offSetX, character.transform.position.y + offSetY, 0), new Vector3(sizeX, sizeY, 1));
    }
}
