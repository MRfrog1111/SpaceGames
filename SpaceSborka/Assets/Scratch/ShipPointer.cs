
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ShipPointer: MonoBehaviour
{
	
	public Transform Target;
	public RectTransform PointerUI;
	public Sprite PointerIcon; 
	public Sprite OutOfScreenIcon; 
	public float InterfaceScale = 100; 
	private Vector3 startPointerSize;
	private Camera mainCamera;


	private void Awake()
	{
		startPointerSize = PointerUI.sizeDelta;
		mainCamera = Camera.main;
	}
	private void LateUpdate()
	{
		Vector3 realPos = mainCamera.WorldToScreenPoint(Target.position);
		Rect rect = new Rect(0, 0, Screen.width, Screen.height);

		Vector3 outPos = realPos;
		float direction = 1;

		PointerUI.GetComponent<Image>().sprite = OutOfScreenIcon;

		if (!IsBehind(Target.position)) 
		{
			if (rect.Contains(realPos))
			{
				PointerUI.GetComponent<Image>().sprite = PointerIcon;
			}
		}
		else 
		{
			realPos = -realPos;
			outPos = new Vector3(realPos.x, 0, 0); 
			if (mainCamera.transform.position.y < Target.position.y)
			{
				direction = -1;
				outPos.y = Screen.height;		
			}
		}
		
		float offset = PointerUI.sizeDelta.x / 2;
		outPos.x = Mathf.Clamp(outPos.x, offset, Screen.width - offset);
		outPos.y = Mathf.Clamp(outPos.y, offset, Screen.height - offset);

		Vector3 pos = realPos - outPos;

		RotatePointer(direction * pos);

		PointerUI.sizeDelta = new Vector2(startPointerSize.x / 100 * InterfaceScale, startPointerSize.y / 100 * InterfaceScale);
		PointerUI.anchoredPosition = outPos;
	}
	private bool IsBehind(Vector3 point) 
	{
		Vector3 forward = mainCamera.transform.TransformDirection(Vector3.forward);
		Vector3 toOther = point - mainCamera.transform.position;
		if (Vector3.Dot(forward, toOther) < 0) return true;
		return false;
	}
	private void RotatePointer(Vector2 direction) 
	{
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		PointerUI.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}


}