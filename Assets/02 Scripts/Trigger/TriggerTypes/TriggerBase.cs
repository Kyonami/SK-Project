using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerBase : MonoBehaviour
{
	[SerializeField]
	private float width = 0f;
	[SerializeField]
	private float center = 0f;
	protected bool isInitialized = false;

	[SerializeField]
	TriggeredActionBase[] onTriggerPulled;

	protected float Left => transform.position.x - center - this.width / 2;
	protected float Right => transform.position.x - center + this.width / 2;

	public void Init(float width, float center)
	{
		this.width = width;
		this.center = center;
		this.isInitialized = true;
	}
	public override string ToString()
	{
		return isInitialized ? "width : " + width + ", center :" + center + "\n" : "Not Initialized";
	}
	private void Start()
	{
		TriggerManager.Instance.AddTrigger(this);
	}
	
	private void OnDestroy()
	{
		TriggerManager.Instance?.RemoveTrigger(this);
	}

	public void PullTrigger()
	{
		Debug.Log("Trigger Pulled : " + ToString());

		for (int i = 0; i < onTriggerPulled.Length; i++)
			onTriggerPulled[i].OnTriggerPulled();
	}

	public abstract bool CheckCollision(float targetX, float targetWidth);
}
