using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	public Transform[] Targets;
	public int NextTarget;
	public float Speed = 3f;
	public float SpeedUpMultiplier = 2f;
	public string HitNameToSpeedUp = "Player";
	public Animator Anim;
	public Transform SpineParent;
	Transform _myObject;
	float _startingSpeed;
	bool _dash = false;

	public Vector3 _lastPosition, _direction, _localDirection;
	void Start()
	{
		_myObject = Targets[NextTarget];
		_startingSpeed = Speed;
	}

	void Update()
	{
		_direction = (transform.position - _lastPosition).normalized;
		_lastPosition = transform.position;

		RaycastHit hit;
		if (Physics.Raycast(transform.position, _direction, out hit, Mathf.Infinity))
		{
			var hitName = hit.transform.gameObject.name;
			if (hitName == HitNameToSpeedUp)
			{
				_dash = true;
				Speed = _startingSpeed * SpeedUpMultiplier;
			}
			else
			{
				_dash = false;
				Speed = _startingSpeed;
            }
        }

		if (_direction.x > 0)
		{
			SpineParent.localScale = new Vector3(1, 1, 1);
		}
		else 
		{
			SpineParent.localScale = new Vector3(-1, 1, 1);
		}

		if (_dash)
		{
			Anim.Play("dash");
		}
		else
		{
			Anim.Play("walk");
		}

        MoveObject();
	}

	void MoveObject()
	{
		this.transform.position = Vector3.MoveTowards(
			this.transform.position,
			_myObject.position,
			Speed * Time.deltaTime
		);
		if (this.transform.position == _myObject.position)
		{
			NextTarget++;
			if (NextTarget == Targets.Length)
			{
				NextTarget = 0;
			}
		}
		_myObject = Targets[NextTarget];

	}
}
