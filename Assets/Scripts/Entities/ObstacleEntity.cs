using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEntity : MonoBehaviour
{
    [SerializeField]
    private string m_playerTag;

    private void OnTriggerEnter2D(Collider other)
    {
        if (other.CompareTag(m_playerTag))
        {
            other.GetComponent<PlayerEntity>().Kill();
        }
    }
}
