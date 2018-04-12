using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class FalconHeavy : MonoBehaviour {

	//public GameObject Payload;
	//public GameObject secondStage;
	public GameObject booster_test;
	public BezierWalkerWithSpeed bzWalker;

	// Use this for initialization
	void Start () {
		booster_test = GetComponentInChildren<Booster>().gameObject;
		Debug.Log("Booster name : " + booster_test.name);
	}
	void Update()
	{
		
	}

	public void PauseWalkers(bool b){
		foreach(BezierWalkerWithSpeed w in GetComponentsInChildren<BezierWalkerWithSpeed>()){
			w.enabled = !b;
		}
		bzWalker.enabled = !b;
	}
}
