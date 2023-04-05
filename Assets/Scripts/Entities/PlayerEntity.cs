using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
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

    private Rigidbody2D m_rb;
    private float m_moveForce = 0f;
    private float m_flyingForce = 0f;
    private bool m_isAlive = true;

    [SerializeField]
    private float m_moveForceScale = 1f;
    [SerializeField]
    private float m_flyingForceScale = 1f;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!m_isAlive
            || !GameManager.Instance.IsGameStarted
            || !GameManager.Instance.IsGamePaused)
        {
            return;
        }

        m_rb.AddForce(m_moveForce * m_moveForceScale * Vector2.right);
        m_rb.AddForce(m_flyingForce * m_flyingForceScale * Vector2.up);
        m_rb.freezeRotation = Mathf.Approximately(m_flyingForce, 0f);
    }

    public void Spawn()
    {
        m_isAlive = true;
        m_rb.isKinematic = false;
    }

    public void Kill()
    {
        m_isAlive = false;
        m_rb.isKinematic = true;
    }
}
