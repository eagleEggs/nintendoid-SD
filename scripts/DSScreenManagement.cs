using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DSScreenManagement : MonoBehaviour {

	[Header("nintendoid-SD")]
	[Header("Scroll Rect Objects:")]
	[SerializeField] private ScrollRect topScreen;
	[SerializeField] private ScrollRect bottomScreen;
	[Header("Adjustments:")]
	[SerializeField] private float screenOffsetBase=0;
	
	void Start(){}

	void Update () {

		if(bottomScreen.verticalNormalizedPosition >= screenOffsetBase{
		topScreen.verticalNormalizedPosition = bottomScreen.verticalNormalizedPosition;
		}

}


}
