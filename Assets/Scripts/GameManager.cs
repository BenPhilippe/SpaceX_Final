using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public bool isPlayMode;
	public bool isRewinding;
	public float timeValue, minTimeValue, maxTimeValue, timeMultiplier;
	public List<Phase> phases;

	void Start()
	{
		timeValue = minTimeValue;

	}
}
