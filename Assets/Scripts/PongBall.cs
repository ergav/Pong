using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.Serialization;

public class PongBall : MonoBehaviour
{

    
    [SerializeField]private Vector3 _direction;
    [SerializeField]private float _moveSpeed = 10f;

    private float initialSpeed;

    private bool moving;

    private void Start()
    {
        // Set the initial direction of the object
        _direction = new Vector2(1, 1).normalized;
        initialSpeed = _moveSpeed;
        StartCoroutine(StartMoving());
    }

    private void Update()
    {
        // Move the object in the current direction

        if (moving)
        {
            transform.position += (Vector3)_direction * (_moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position += Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the normal vector of the surface the object collided with
        var surfaceNormal = collision.contacts[0].normal;

        // Calculate the reflected direction vector
        _direction = Vector2.Reflect(_direction, surfaceNormal);

        _moveSpeed++;
    }

    public void ResetBall()
    {
        moving = false;
        transform.position = Vector3.zero;
        _moveSpeed = initialSpeed;
        StartCoroutine(StartMoving());
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(1);
        moving = true;
    }
}