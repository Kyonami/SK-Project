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
			"~~������ �����ϴ� ���~~\n" +
			"1. BoxCollider�� �߰��Ѵ�.\n" +
			"2. Edit Collider������� ���ϴ� ��ŭ�� ũ�⸦ �����Ѵ�.\n" +
			"3.ũ�� ���� ��ư�� ������.\n" +
			"- ���� ������Ʈ�� ���� ���� ���, \"������Ʈ ũ�� �ڵ� �Է� ��ư\"�� ���� �ڵ����� ������Ʈ ũ�� �Է��� �����ϴ�.", MessageType.Info); ;

		if (GUILayout.Button("ũ�� ����"))
		{
			BoxCollider collider = target.GetComponent<BoxCollider>();
			if (collider == null) return;
			trigger.Init(collider.size.x, collider.center.x);
			DestroyImmediate(collider);
		}
		if (GUILayout.Button("���� ������Ʈ ũ�� �ڵ� �Է�"))
		{
			BoxCollider collider = target.AddComponent<BoxCollider>();
			trigger.Init(collider.size.x, collider.center.x);
			DestroyImmediate(collider);
		}
	}

}
