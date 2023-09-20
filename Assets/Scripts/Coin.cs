using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private int _cost;

    public int Cost => _cost;

    private void Update()
    {
        transform.Rotate(_rotation);
    }
}
