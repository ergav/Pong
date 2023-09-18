using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pong : MonoBehaviour
{
    private float move;
    [SerializeField] private float speed = 5f;

    private Vector3 some;

    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }

    public void MoveRectangle(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<float>();
        some = Vector2.up * (move * speed * Time.deltaTime);
    }

    private void Update()
    {
        float posY = transform.position.y + move * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Math.Clamp(posY, -3.3f, 3.3f), transform.position.z);
    }
}