using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.UIElements;

[CustomEditor(typeof(TriggerBase), true)]
public class TriggerEditor : Editor
{
	TriggerBase trigger = null;

	private void OnEnable()
	{
		trigger = (TriggerBase)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		EditorGUILayout.Space();

		EditorGUILayout.HelpBox(
			"~~사이즈 조절하는 방법~~\n" +
			"1. BoxCollider를 추가한다.\n" +
			"2. Edit Collider기능으로 원하는 만큼의 크기를 지정한다.\n" +
			"3.크기 적용 버튼을 누른다.\n" +
			"- 만약 오브젝트가 따로 있을 경우, \"오브젝트 크기 자동 입력 버튼\"을 통해 자동으로 오브젝트 크기 입력이 가능하다.", MessageType.Info); ;

		if (GUILayout.Button("크기 적용"))
		{
			BoxCollider collider = target.GetComponent<BoxCollider>();
			if (collider == null) return;
			trigger.Init(collider.size.x, collider.center.x);
			DestroyImmediate(collider);
		}
		if (GUILayout.Button("게임 오브젝트 크기 자동 입력"))
		{
			BoxCollider collider = target.AddComponent<BoxCollider>();
			trigger.Init(collider.size.x, collider.center.x);
			DestroyImmediate(collider);
		}
	}

}
