using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class FalconHeavy : MonoBehaviour {

	//public GameObject Payload;
	//public GameObject secondStage;
	public GameObject booster_test;
	public BezierWalkerWithSpeed bzWalker;
	public SpeedManager speedManager;

	// Use this for initialization
	void Start () {
		booster_test = GetComponentInChildren<Booster>().gameObject;
		Debug.Log("Booster name : " + booster_test.name);
	}
	void Update()
	{
		
	}

	public void InvertDirection(){
		foreach(BezierWalkerWithSpeed w in GetComponentsInChildren<BezierWalkerWithSpeed>()){
			w.isGoingForward = !w.isGoingForward;
		}
		bzWalker.isGoingForward = !bzWalker.isGoingForward;
	}

	public void PauseWalkers(bool b){
		foreach(BezierWalkerWithSpeed w in GetComponentsInChildren<BezierWalkerWithSpeed>()){
			w.enabled = !b;
		}
		foreach(SpeedManager s in GetComponentsInChildren<SpeedManager>()){
			s.enabled = !b;
		}

		foreach(ParticleSystem ps in GetComponentsInChildren<ParticleSystem>()){
			ps.enableEmission = !b;
		}
		bzWalker.enabled = !b;
		speedManager.enabled = !b;
	}
}
