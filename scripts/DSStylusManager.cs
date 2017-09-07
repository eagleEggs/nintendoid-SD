using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSStylusManager : MonoBehaviour {

	[SerializeField] 	private Animator stylusAnimator;
						private bool stylusAnimationComplete=false;

	void Start(){

		StartCoroutine (retractStylus());


	}

	void Update(){

		if(stylusAnimationComplete){
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x+60f, Input.mousePosition.y+50f, distance_to_screen ));
	}
	}

	IEnumerator retractStylus(){

		yield return new WaitForSeconds(0.5f);
		stylusAnimator.SetTrigger("stylus");
		yield return new WaitForSeconds(1f);
		stylusAnimator.SetBool("stylus", false);
		stylusAnimationComplete=true;
		stylusAnimator.animatePhysics=true;
		yield return null;

	}


}
