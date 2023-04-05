using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEntity : MonoBehaviour
{
    private PlayerEntity m_player;

    private float m_velocity = 0f;
    [SerializeField]
    private float m_moveSmoothTime = 0.2f;

    private void Start()
    {
        GameManager.Instance.OnGameStart += OnGameStart;
    }

    private void OnGameStart()
    {
        m_player = FindObjectOfType<PlayerEntity>();
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameStarted)
        {
            return;
        }

        var pos = transform.position;

        pos.x = Mathf.SmoothDamp(
            pos.x,
            m_player.transform.position.x,
            ref m_velocity,
            m_moveSmoothTime
        );

        transform.position = pos;
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
