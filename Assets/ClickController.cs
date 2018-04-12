using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour {

	public TargetFollower follower;
	public GameManager GM;
	
	void Update () {
		if(!GM.isPlayMode){
			if(Input.GetMouseButtonDown(0)){
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit, 1500f)){
					ModuleClick mc = hit.collider.gameObject.GetComponent<ModuleClick>();
					if (mc != null){
						follower.ChangeTarget(mc.transform);
					}
				}
			}

		}
		
	}
}
