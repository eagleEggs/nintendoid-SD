using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DSScreenManagement : MonoBehaviour {

	public ScrollRect bottomScreen;
	public ScrollRect topScreen;


	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {

		if(bottomScreen.verticalNormalizedPosition >=0){

			//Debug.Log (bottomScreen.verticalNormalizedPosition);

			//scrollRect.horizontalNormalizedPosition = Mathf.Clamp(scrollRect.horizontalNormalizedPosition, 0f, 1f);
		

		topScreen.verticalNormalizedPosition = bottomScreen.verticalNormalizedPosition;
		
	}
}
}