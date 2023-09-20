using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Animator _animator;
    private int _coinsCount;    

    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private int _health;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private GameObject _damageEffect;

    private const string _idleAnimation = "idle";
    private const string _walkAnimation = "walk";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        Move();
        Animations();
    }

    private void Move()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, _speedRotation * -1, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, _speedRotation, 0);
        }
    }

    private void Animations()
    {
        if (transform.position.z == 0)
        {
            _animator.Play(_idleAnimation);
        }
        else
        {
            _animator.Play(_walkAnimation);
        }
    }

    private void TakeDamage(int cost)
    {
        _coinsCount -= cost;
    }

    private void TakePrice(int damage)
    {
        _health -= damage;
    }


    private void AnimationsActivate(GameObject effect)
    {
        Instantiate(effect, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Coin>(out Coin coin))
        {
            TakePrice(coin.Cost);
            Destroy(collision.gameObject);            
        }

        if (collision.collider.TryGetComponent<Trap>(out Trap trap))
        {
            TakeDamage(trap.Damage);
            AnimationsActivate(_damageEffect);
        }

        if (collision.collider.TryGetComponent<Ground>(out Ground ground) && _isGrounded == false)
        {
            TakeDamage(ground.Damage);
            AnimationsActivate(_damageEffect);
            _isGrounded = true;
        }

        if (collision.collider.TryGetComponent<Pillow>(out Pillow pillow) && _isGrounded == false)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent<Ground>(out Ground ground) && _isGrounded == true)
        {
            _isGrounded = false;
        }
    }


}
