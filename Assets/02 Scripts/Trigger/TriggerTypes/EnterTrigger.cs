using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : TriggerBase
{
	protected bool isStaying = false;

	public override bool CheckCollision(float targetX, float width)
	{
		// goes in
		if (Left - (width / 2) <= targetX && targetX <= Right +(width / 2))
		{
			if (isStaying)
				return false;

			isStaying = true;
			return true;
		}
		
		// goes out
		if (isStaying)
			isStaying = false;

		return false;
	}
}
