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
    private int m_groundMask;
    private float m_moveForce = 0f;
    private float m_flyingForce = 0f;
    private bool m_isAlive = true;
    private float m_rotVel = 0f;

    [SerializeField]
    private float m_moveForceScale = 1f;
    [SerializeField]
    private float m_flyingForceScale = 1f;
    [SerializeField]
    private float m_minGroundDistance = 1f;
    [SerializeField]
    private float m_rotationSmoothTime = 0f;
    [SerializeField]
    private string m_groundLayerName = string.Empty;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_groundMask = LayerMask.GetMask(m_groundLayerName);
    }

    private void Update()
    {
        GameManager.Instance.OnGameStart += Spawn;
    }

    private void FixedUpdate()
    {
        if (!m_isAlive
            || !GameManager.Instance.IsGameStarted
            || GameManager.Instance.IsGamePaused)
        {
            return;
        }

        m_rb.AddForce(m_flyingForce * m_flyingForceScale * Vector2.up);

        bool isGrounded = IsGrounded();
        m_rb.freezeRotation = !isGrounded;

        if (!isGrounded)
        {
            m_rb.AddForce(m_moveForce * m_moveForceScale * Vector2.right);
            m_rb.rotation = Mathf.SmoothDampAngle(m_rb.rotation, 0f, ref m_rotVel, m_rotationSmoothTime);
        }
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

    private bool IsGrounded()
    {
        var hit = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y),
            Vector2.down,
            m_minGroundDistance,
            m_groundMask
        );

        Debug.Log(hit);
        return hit.collider != null && hit.distance < m_minGroundDistance;
    }
}
