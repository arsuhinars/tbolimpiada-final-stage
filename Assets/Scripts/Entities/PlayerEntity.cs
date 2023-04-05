using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public float MoveForce
    {
        get => m_moveForce;
        set => m_moveForce = value;
    }

    public float FlyingForce
    {
        get => m_flyingForce;
        set => m_flyingForce = value;
    }

    private float m_moveForce = 0f;
    private float m_flyingForce = 0f;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void Jump()
    {

    }

    public void Spawn()
    {

    }

    public void Kill()
    {

    }
}
