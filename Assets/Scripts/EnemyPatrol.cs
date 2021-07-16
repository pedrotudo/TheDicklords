using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	public Transform[] Targets;
	public int NextTarget;
	public float Speed = 3f;
	Transform _myObject;

	void Start()
	{
		_myObject = Targets[NextTarget];
	}

	void Update()
	{
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
