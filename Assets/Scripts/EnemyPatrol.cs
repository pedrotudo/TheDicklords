using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	public Transform[] Targets;
	public int NextTarget;
	public float Speed = 3f;
	Transform _myObject;
	float _startingSpeed;

	public Vector3 _lastPosition, _direction, _localDirection;
	void Start()
	{
		_myObject = Targets[NextTarget];
		_startingSpeed = Speed;
	}

	void Update()
	{
		_direction = (transform.position - _lastPosition).normalized;
		_localDirection = transform.InverseTransformDirection(_direction);
		_lastPosition = transform.position;

		RaycastHit hit;
		// Does the ray intersect any objects excluding the player layer
		if (Physics.Raycast(transform.position, _direction, out hit, Mathf.Infinity))
		{
			var hitName = hit.transform.gameObject.name;
			Debug.Log($"hitting {hitName}");
			if (hitName == "Player")
			{
				Speed = _startingSpeed * 2;
			}
			else
			{
				Speed = _startingSpeed;
			}
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
