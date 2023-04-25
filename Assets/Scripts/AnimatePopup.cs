using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimatePopup : MonoBehaviour
{
	Transform Panel;
	private void Awake()
	{
		Panel = this.transform.GetChild(0);
	}
	private void OnEnable()
	{
		Panel.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.3f).From();
	}
}