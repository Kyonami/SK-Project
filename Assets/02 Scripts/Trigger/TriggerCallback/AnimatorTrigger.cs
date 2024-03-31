using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTrigger : TriggeredActionBase
{
	[SerializeField]
	private Animator animator = null;
	[SerializeField]
	private string triggerName = string.Empty;

	public override void OnTriggerPulled()
	{
		animator.SetTrigger(triggerName);
	}
}
