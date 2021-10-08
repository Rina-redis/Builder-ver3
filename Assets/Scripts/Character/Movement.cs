using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField]private float movementSpeed = 5f;
    Rigidbody2D rigidbody;
    Animator animator;

    public Vector2 movement;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
    private void Update()
    {
        Move();
    }
}
