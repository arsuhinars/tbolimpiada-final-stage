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
        m_player.MoveForce = context.ReadValue<Vector2>().x;
    }

    public void OnSpaceInputAction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            m_player.FlyingForce = 1f;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            m_player.FlyingForce = 0f;
        }
    }
}
