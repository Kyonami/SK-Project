using System;
using UnityEngine;


public class Player : MonoBehaviour
{
	[SerializeField]
	private float maxSpeed = 5f;
	[SerializeField]
	private float deltaSpeed = 0.05f;
	[SerializeField]
	private float runningSpeedRatio = 2f;

	private float currentSpeed = 0f;
	private float currentMaxSpeed = 5f;
	private sbyte direction = 0;

		
	private bool IsRight()
	{
		return direction == 1;
	}

	private bool IsLeft()
	{
		return direction == -1;
	}

	// Update is called once per frame
	private void Update()
	{
		currentMaxSpeed = Input.GetKey(KeyCode.LeftShift) ? maxSpeed * runningSpeedRatio : maxSpeed;

		if (!IsRight() && Input.GetKey(KeyCode.LeftArrow))
		{
			direction = -1;
			if (currentSpeed < -currentMaxSpeed)	// max 속도로 맞춰주는 과정
				currentSpeed += deltaSpeed;
			else
				currentSpeed -= deltaSpeed;
		}
		else if(!IsLeft() && Input.GetKey(KeyCode.RightArrow))
		{
			direction = 1;
			if (currentMaxSpeed < currentSpeed)		// max 속도로 맞춰주는 과정
				currentSpeed -= deltaSpeed;
			else
				currentSpeed += deltaSpeed;
		}
		else
		{
			currentSpeed += deltaSpeed * -direction;
			if ((IsLeft() && 0 <= currentSpeed) || (IsRight() && currentSpeed <= 0))
			{
				currentSpeed = 0;
				direction = 0;
			}
		}
	}
	private void LateUpdate()
	{
		transform.position += Vector3.right * Time.deltaTime * currentSpeed;
	}
}
