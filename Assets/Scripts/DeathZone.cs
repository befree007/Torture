using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            Time.timeScale = 0;
            _deathPanel.SetActive(true);
        }

        Destroy(collision.gameObject);
    }
}
