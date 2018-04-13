using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class FalconHeavy : MonoBehaviour {

	public GameObject removeablePart;
	public GameObject secondStage;
	public GameObject boosterDroite, boosterGauche;
	public BezierWalkerWithSpeed bzWalker;
	public SpeedManager speedManager;

	// Use this for initialization
	void Start () {
		
		foreach(Collider c in GetComponentsInChildren<Collider>()){
			if(c != GetComponent<Collider>()){
				c.enabled = false;
			}
		}
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
		/*foreach(BezierWalkerWithSpeed w in GetComponentsInChildren<BezierWalkerWithSpeed>()){
			w.enabled = !b;
		}*/
		foreach(SpeedManager s in GetComponentsInChildren<SpeedManager>()){
			s.enabled = !b;
		}

		foreach(ParticleSystem ps in GetComponentsInChildren<ParticleSystem>()){
			ps.enableEmission = !b;
		}
		bzWalker.enabled = !b;
		speedManager.enabled = !b;
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.name == "BECO_trigger"){
			boosterGauche.GetComponent<Booster>().Detach(bzWalker.speed);
			boosterDroite.GetComponent<Booster>().Detach(bzWalker.speed);
		}
		if(c.gameObject.name == "SECO_trigger"){
			secondStage.GetComponent<Booster>().Detach(bzWalker.speed);
			removeablePart.SetActive(false);
		}
	}
}
