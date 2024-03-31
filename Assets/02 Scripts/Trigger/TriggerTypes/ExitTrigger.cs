using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : TriggerBase
{
	private bool isStaying = false;

	public override bool CheckCollision(float targetX, float width)
	{
		// goes in
		if (Left - (width / 2) <= targetX && targetX <= Right + (width / 2))
		{
			if (!isStaying)
				isStaying = true;

			return false;
		}
		
		// goes out
		if (isStaying) 
		{
			isStaying = false;
			return true;
		}

		return false;
	}
}
