using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    private Movement movementComponent;   
    private bool facingRight = true;
    private void Awake()
    {
        movementComponent = GetComponent<Movement>();
    }
    private void FixedUpdate()
    {
        Flip(movementComponent.movement.x);
    }
    private void Flip(float horizontal)
    {
        if((horizontal!=0) && (horizontal>0 !=facingRight))
        {
            Vector3 characterScale = transform.localScale;
            facingRight = !facingRight;
            characterScale.x *= -1;
            transform.localScale = characterScale;
        }
    }
}
