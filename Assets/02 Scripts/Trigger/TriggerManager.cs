using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ETriggerType
{
	UPDATE,
	TRIGGER
}

/// <summary>
/// TriggerPuller와 Trigger가 각각 별개라고 상정함.
/// </summary>
public class TriggerManager : SingleTon<TriggerManager>
{
	//[SerializeField] private TriggerPuller[] triggerPullers;
	[SerializeField] private TriggerPuller triggerPuller;

	private List<int> triggerIDList = new List<int>();
	private Dictionary<ETriggerType, List<TriggerBase>> triggerList = new Dictionary<ETriggerType, List<TriggerBase>>();

	private void Awake()
	{
		triggerList.Clear();

		triggerPuller = FindObjectOfType<TriggerPuller>();

		foreach (ETriggerType t in System.Enum.GetValues(typeof(ETriggerType)))
			triggerList.Add(t, new List<TriggerBase>());
	}

	private void Update()
	{
		CheckTriggerInUpdate();
	}

	public void ChecKTrigger()
	{
		List<TriggerBase> list = triggerList[ETriggerType.TRIGGER];

		for (int i = 0; i < list.Count; i++)
			if (list[i].CheckCollision(triggerPuller.XPos, triggerPuller.Width))
				list[i].PullTrigger();
	}

	public void AddTrigger(TriggerBase trigger)
	{
		if (triggerIDList.Contains(trigger.GetInstanceID())) return;

		triggerIDList.Add(trigger.GetInstanceID());
		triggerList[GetTriggerType(trigger)].Add(trigger);
	}
	public void RemoveTrigger(TriggerBase trigger)
	{
		if (triggerIDList.Contains(trigger.GetInstanceID())) return;

		triggerIDList.Remove(trigger.GetInstanceID());
		triggerList[GetTriggerType(trigger)].Remove(trigger);
	}


	private void CheckTriggerInUpdate()
	{
		List<TriggerBase> list = triggerList[ETriggerType.UPDATE];

		for (int i = 0; i < list.Count; i++)
			if(list[i].CheckCollision(triggerPuller.XPos, triggerPuller.Width))
				list[i].PullTrigger();
	}
	private ETriggerType GetTriggerType(TriggerBase trigger)
	{
		return trigger is EnterTrigger || trigger is ExitTrigger ? ETriggerType.UPDATE : ETriggerType.TRIGGER;
	}
}
