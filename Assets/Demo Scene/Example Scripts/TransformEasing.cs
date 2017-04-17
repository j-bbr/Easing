using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleEasing;

public class TransformEasing : MonoBehaviour {
	public Transform easeTarget;
	public float length;
	public Vector3 target;
	public EasingTypes easing;
	//So that ther is only one tween active on the transform
	private UniqueCoroutine uniqueAnimation = new UniqueCoroutine();
	
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
		print(enumIndex);
		print(easing);
	}
}
