using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSStylusManager : MonoBehaviour {

	//[SerializeField] private GameObject stylus;

	void Start(){}

	void Update(){
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x+25f, Input.mousePosition.y+50f, distance_to_screen ));

	}

}