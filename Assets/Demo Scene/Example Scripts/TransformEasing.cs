using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleEasing;

public class TransformEasing : MonoBehaviour {
	public Transform easeTarget;
	//0 is position, 1 is scale, 2 is rotation
	public int animatedProperty = 0;
	public List<Toggle> propertyToggles = new List<Toggle>();
	public float length;
	public Vector3 target;
	public EasingTypes easing;
	//So that ther is only one tween active on the transform
	private UniqueCoroutine uniqueAnimation = new UniqueCoroutine();


	void Start()
	{
		uniqueAnimation.ReplaceOrStartTween(
			easeTarget.MoveTo(new Vector3(0, 7f, 0), new Vector3(0, 0.5f, 0), 1.5f, EasingTypes.BounceOut)
		);
	}

	public void EaseScale()
	{
		//So that the tween won't be interfere with a previous tween
		uniqueAnimation.ReplaceOrStartTween(
			easeTarget.ScaleTo(target, length, easing)
		);
	}
	public void EasePosition()
	{
		uniqueAnimation.ReplaceOrStartTween(
			easeTarget.MoveTo(target, length, easing)
		);
	}
	public void EaseRotation()
	{
		uniqueAnimation.ReplaceOrStartTween(
			easeTarget.RotateTo(target, length, easing)
		);
	}
	public void SetAnimationProperty()
	{
		var chosenOption = propertyToggles.Find(x => x.isOn);
		animatedProperty = chosenOption.transform.GetSiblingIndex();
	}
	public void Ease()
	{
		switch(animatedProperty)
		{
		case 0:
			EasePosition();
			break;
		case 1:
			EaseScale();
			break;
		case 2:
			EaseRotation();
			break;
		}
	}

	public void SetLength(string time)
	{
		if(string.IsNullOrEmpty(time))
			length = 0f;
		else
			length = float.Parse(time);
	}

	public void SetX(string x)
	{
		if(string.IsNullOrEmpty(x))
			target.x = 0f;
		else
			target.x = float.Parse(x);
	}

	public void SetY(string y)
	{
		if(string.IsNullOrEmpty(y))
			target.y = 0f;
		else
			target.y = float.Parse(y);
	}

	public void SetZ(string z)
	{
		if(string.IsNullOrEmpty(z))
			target.z = 0f;
		else
			target.z = float.Parse(z);
	}

	public void SetEasing(int enumIndex)
	{
		easing = (EasingTypes)enumIndex;
	}
}
