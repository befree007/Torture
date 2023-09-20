using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Vector3 _rotation;

    public int Damage => _damage;

    private void Update()
    {
        transform.Rotate(_rotation);
    }
}
