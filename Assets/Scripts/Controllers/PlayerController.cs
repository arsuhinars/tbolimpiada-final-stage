using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerEntity))]
public class PlayerController : MonoBehaviour
{
    private PlayerEntity m_player;

    private void Awake()
    {
        m_player = GetComponent<PlayerEntity>();
    }

    public void OnMoveInputAction(InputAction.CallbackContext context)
    {

    }

    public void OnJumpInputAction(InputAction.CallbackContext context)
    {

    }
}
