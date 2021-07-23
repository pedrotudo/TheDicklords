using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public int HP;
}

public class Player : MonoBehaviour
{
    private PlayerModel _playerModel;
    public PlayerModel PlayerModel;
    public int HitPoints => _playerModel.HP;

    public static Action<int> OnPlayerHitpointsChange;
    public static Action OnPlayerIsDead;
    public float speed;
    public Animator Anim;
    public Transform SpineParent;

    private Rigidbody _rb;
    public Vector3 _lastPosition, _direction;
    bool _isMoving;
    private bool _isDead;

    public void Initalize(PlayerModel playerModel)
    {
        _playerModel = playerModel;
        OnPlayerHitpointsChange?.Invoke(_playerModel.HP);
    }

    private void Awake()
    {
        Debug.Log("Awake Player");

        _rb = GetComponent<Rigidbody>();

        _isDead = false;

        GameEvents.OnCustomEvent += OnCustomEventBehaviour;
        OnPlayerHitpointsChange += CheckHealth;
    }

    private void OnCustomEventBehaviour(string eventName, string value)
    {
        if (string.Equals(eventName, "life"))
        {
            HitpointsChange(int.Parse(value));
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy Player");
        GameEvents.OnCustomEvent -= OnCustomEventBehaviour;
        OnPlayerHitpointsChange -= CheckHealth;
    }


    void FixedUpdate()
    {
        if (_isDead)
            return;

        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        Vector3 velocity = new Vector3(h, 0, v).normalized * speed;

        _rb.velocity = velocity;

        if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }

        _direction = (transform.position - _lastPosition).normalized;
        _lastPosition = transform.position;

        // flip spineParent
        if (_direction.x > 0)
        {
            SpineParent.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            SpineParent.localScale = new Vector3(-1, 1, 1);
        }
        if (_isMoving)
        {
            Anim.Play("walk");
        }
        else
        {
            Anim.Play("idle");
        }

    }
    private void HitpointsChange(int delta)
    {
        _playerModel.HP += delta;
        OnPlayerHitpointsChange?.Invoke(_playerModel.HP);
    }

    private void CheckHealth(int currentHp)
    {
        if (_playerModel.HP <= 0)
        {
            Anim.Play("death");
            _rb.velocity = Vector3.zero;
            _isDead = true;
            OnPlayerIsDead?.Invoke();
        }
    }

}
