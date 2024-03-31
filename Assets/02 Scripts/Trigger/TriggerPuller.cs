using UnityEngine;

public class TriggerPuller : MonoBehaviour
{
	[SerializeField]
	private float width;
	public float Width => width;
	public float XPos => transform.position.x;
}
