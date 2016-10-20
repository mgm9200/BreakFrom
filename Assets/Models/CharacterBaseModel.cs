using UnityEngine;
using System.Collections;

public class CharacterBaseModel : MonoBehaviour
{

    public float Speed = .10f;
    public int jumpPower = 10;
    public float GrabRay = 1f;
    public float GroundRay = .4f;
    public Transform grabRayOrigin;
    public Transform[] groundRaysOrigins;

    public bool Grounded { get; private set; }
    public bool Hang { get; private set; }
    public float vSpeed { get; private set; }
    public float Movement { get; private set; }
    private bool isFacingRight = true;

    public LayerMask WhatIsGround;

    private int Health = 10;
    private Vector3 position;
    private Rigidbody2D rb;
    private RaycastHit2D hit;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //no colisionar consigo mismo
        Physics2D.raycastsStartInColliders = false;
        //lanzar ray para saber si esta cerca de una pared
        hit = Physics2D.Raycast(grabRayOrigin.position, Vector3.right * transform.localScale.x, GrabRay);
        Grounded = CheckIfGrounded();
        Debug.Log(Grounded);
        vSpeed = rb.velocity.y;

    }


    void Update()
    {

        //si esta saltando y hay pared cerca
        if (!Grounded && hit.collider != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GrabWall(hit.normal);
        }

    }

    bool CheckIfGrounded()
    {
        
        foreach (Transform item in groundRaysOrigins)
        {
            if (Physics2D.Raycast(item.position, Vector2.down, GroundRay, WhatIsGround))
                return true;
        }

        return false;
    }

    public void Move(float movement)
    {
        if (Hang)
            return;

        Movement = movement;
        rb.velocity = new Vector2(Movement * Speed, vSpeed);

        if (Movement > 0 && !isFacingRight)
            Flip();
        else if (Movement < 0 && isFacingRight)
            Flip();
    }

    public void Action()
    {
        if (Grounded && !Hang)
        {
            Grounded = false;
            rb.AddForce(new Vector2(0, jumpPower));
        }
        else if (Hang)
        {
            Hang = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(new Vector2(jumpPower, jumpPower));

        }
    }

    public void GrabWall(Vector2 normal)
    {
        Hang = true;
        if (normal.x == -1 && isFacingRight)
            Flip();
        else if (normal.x == 1 && !isFacingRight)
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 oldScale = transform.localScale;
        oldScale.x *= -1;
        transform.localScale = oldScale;
    }

    void OnDrawGizmos()
    {
        

    }
}
