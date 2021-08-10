using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{
    [SerializeField] private GameObject leftPortal;
    [SerializeField] private GameObject rightPortal;
    private Quaternion rightRotation = Quaternion.Euler(0,0,0);
    private Quaternion leftRotation = Quaternion.Euler(0,0,180);
    private Quaternion upRotation = Quaternion.Euler(0,0,90);
    private Quaternion downRotation = Quaternion.Euler(0,0,270);
    
    protected override void SetNextDirection()
    {
        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal < 0)
            nextDirection = Vector2.left;
        else if (horizontal > 0)
            nextDirection = Vector2.right;
        else if (vertical < 0)
            nextDirection = Vector2.down;
        else if (vertical > 0)
            nextDirection = Vector2.up;
    }

    protected override void SetAnimation()
    {
        if (currentDirection == Vector2.down)
            transform.rotation = downRotation;
        else if (currentDirection == Vector2.up)
            transform.rotation = upRotation;
        else if (currentDirection == Vector2.left)
            transform.rotation = leftRotation;
        else if (currentDirection == Vector2.right)
            transform.rotation = rightRotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == leftPortal && currentDirection == Vector2.left)
        {
            transform.position = rightPortal.transform.position;
        }
        else if (other.gameObject == rightPortal && currentDirection == Vector2.right)
        {
            transform.position = leftPortal.transform.position;
        }
    }
}