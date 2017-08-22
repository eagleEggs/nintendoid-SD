using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DSManagement : MonoBehaviour {

	[SerializeField]/* 					  */public 	GameObject 		ds;
	[SerializeField]/* 					  */public 	GameObject 		dsTop;
	[SerializeField]/* 					  */public 	GameObject 		dsBottom;
	[SerializeField]/* 					  */public 	Animator 		dsAnimation;
	[SerializeField]/* 					  */private bool 			dsIsOpen;
	[SerializeField]/* 					  */private bool 			dsSpotPass;
	[SerializeField]/* 					  */private bool 			dsStreetPass;
	[SerializeField]/* 					  */private bool 			dsLowBattery;
	[SerializeField]/* 					  */private bool 			dsSideCameraOn=true;
					/* 					  */private bool 			dsIsSpinningSide;
					/* 					  */private bool 			dsIsSpinningUpSide;
					/* 					  */private bool 			dsIsSounding;
	[SerializeField]	[Range(0, +100)]	private float 			dsCloseOpenAmount;
	[SerializeField]	[Range(0, +100)]	private float 			dsSpinSpeed;
	[SerializeField]	[Range(0, +100)]	private float 			dsBrightness;
	[SerializeField]/* 					  */private ScrollRect 		dsUIScrollRect;
	[SerializeField]/* 					  */private	RectTransform 	dsUIScrollRectContent;
	[SerializeField]/* 					  */private Button 			openDSButton;
	[SerializeField]/* 					  */private Button 			spinSideDSButton;
	[SerializeField]/* 					  */private Button 			dsSwitchCamera;
	[SerializeField]/* 					  */private Camera 			dsSideCamera;
	[SerializeField]/* 					  */private Camera 			dsFrontCamera;
	[SerializeField]/* 					  */private Camera 			dsCloseCamera;
											private int 			closeCam;

	void Start(){

		dsIsOpen=true;

		Button theOpenDSButton = openDSButton.GetComponent<Button>();
    	Button theSpinSideDSButton = spinSideDSButton.GetComponent<Button>();

    	theOpenDSButton.onClick.AddListener(openCloseDSFunction);
    	theSpinSideDSButton.onClick.AddListener(spinSideFunction);

    	Button theCameraSwitch = dsSwitchCamera.GetComponent<Button>();
    	theCameraSwitch.onClick.AddListener(dsCameraSwitchFunction);



	}


	void dsCameraSwitchFunction(){

		if(dsSideCameraOn==true){

		dsSideCamera.enabled=false;
		dsFrontCamera.enabled=true;
		dsSideCameraOn=false;

		} else {

			dsFrontCamera.enabled=false;
			dsSideCamera.enabled=true;
			dsSideCameraOn=true;


		} 




		}

	

	void openCloseDSFunction(){

		if  (dsIsOpen)	{dsAnimation.SetTrigger("seeYouOnTheFlippityFlip"); dsIsOpen=false;}
		else 			{dsAnimation.SetTrigger("seeYouOnTheFlippityFlop"); dsIsOpen=true;}


	}

	void spinSideFunction(){

		dsAnimation.SetTrigger("spinSide");
		//dsAnimation.SetBool("spinSide", false);

		//else 					{dsAnimation.SetTrigger("spinSide"); dsIsSpinningSide=true;}


	}

	void Update(){




	}



}