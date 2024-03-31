using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : TriggerBase
{
	public override bool CheckCollision(float targetX, float width)
	{
		return Left - (width / 2) <= targetX && targetX <= Right + (width / 2);
	}
}
