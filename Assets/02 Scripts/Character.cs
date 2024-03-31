using System;
using UnityEngine;


public class Character : MonoBehaviour
{
	[SerializeField]
	private Transform model = null;
	[SerializeField]
	private Animator animator = null;
	[SerializeField]
	private float maxSpeed = 5f;
	[SerializeField]
	private float accelerateSpeed = 0.1f;
	[SerializeField]
	private float decelerateSpeed = 0.1f;
	[SerializeField]
	private float runningSpeedRatio = 2f;

	private float currentSpeed = 0f;
	private float currentMaxSpeed = 5f;
	private sbyte direction = 0;


	// Update is called once per frame
	private void Update()
	{
		if(Input.GetKey(KeyCode.LeftShift))
		{
			animator.SetBool("isRunning", true);
			currentMaxSpeed = maxSpeed * runningSpeedRatio;
		}
		else
		{
			animator.SetBool("isRunning", false);
			currentMaxSpeed = maxSpeed;
		}

		if(Input.GetKeyDown(KeyCode.Z))
		{
			TriggerManager.Instance.ChecKTrigger();
		}

		if (!IsRight() && Input.GetKey(KeyCode.LeftArrow))
		{
			animator.SetBool("isMoving", true);
			direction = -1;
			if (currentSpeed < -currentMaxSpeed)	// max 속도로 맞춰주는 과정
				currentSpeed += accelerateSpeed;
			else
				currentSpeed -= decelerateSpeed;

			model.LookAt(model.position + Vector3.left);
		}
		else if(!IsLeft() && Input.GetKey(KeyCode.RightArrow))
		{
			animator.SetBool("isMoving", true);
			direction = 1;
			if (currentMaxSpeed < currentSpeed)		// max 속도로 맞춰주는 과정
				currentSpeed -= accelerateSpeed;
			else
				currentSpeed += decelerateSpeed;
			model.LookAt(model.position + Vector3.right);
		}
		else
		{
			animator.SetBool("isMoving", false);
			currentSpeed += decelerateSpeed * -direction;
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

	private bool IsRight()
	{
		return direction == 1;
	}

	private bool IsLeft()
	{
		return direction == -1;
	}

}
