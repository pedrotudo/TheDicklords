using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _hitPoints;

    public static Action OnPlayerHitpointsChange;
    public static Action OnPlayerIsDead;

    public float speed;
    private Rigidbody _rb;
    private void Awake()
    {
        Debug.Log("Awake Player");

        _rb = GetComponent<Rigidbody>();
        OnPlayerHitpointsChange += CheckHealth;
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy Player");
        OnPlayerHitpointsChange -= CheckHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * speed;

        _rb.velocity = velocity;
    }

    private void HitpointsChange(int delta)
    {
        _hitPoints += delta;
        OnPlayerHitpointsChange?.Invoke();
    }

    private void CheckHealth()
    {
        if (_hitPoints <= 0)
        {
            OnPlayerIsDead?.Invoke();
        }
    }

}
