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
	[SerializeField]/* 					  */private bool 			dsSpotPass=false;
	[SerializeField]/* 					  */private bool 			dsStreetPass=false;
	[SerializeField]/* 					  */private bool 			dsLowBattery;
	[SerializeField]/* 					  */private bool 			dsSideCameraOn=true;
					/* 					  */private bool 			dsIsSpinningSide;
					/* 					  */private bool 			dsIsSpinningUpSide;
					/* 					  */private bool 			dsIsSounding;
	[SerializeField]	[Range(0, +2)]		private float 			dsCloseOpenAmount;
	[SerializeField]	[Range(0, +100)]	private float 			dsSpinSpeed;
	[SerializeField]	[Range(0, +5)]		private float 			dsBrightness;
	[SerializeField]/* 					  */private ScrollRect 		dsUIScrollRect;
	[SerializeField]/* 					  */private	RectTransform 	dsUIScrollRectContent;
	[SerializeField]/* 					  */private Button 			openDSButton;
	[SerializeField]/* 					  */private Button 			spinSideDSButton;
	[SerializeField]/* 					  */private Button 			dsSwitchCamera;
	[SerializeField]/* 					  */private Button 			dsStreetPassButton;
	[SerializeField]/* 					  */private Button 			dsSpotPassButton;
	[SerializeField]/* 					  */private Button 			dsBatteryButton;
	[SerializeField]/* 					  */private Camera 			dsSideCamera;
	[SerializeField]/* 					  */private Camera 			dsFrontCamera;
	[SerializeField]/* 					  */private Camera 			dsCloseCamera;
	[SerializeField]/* 					  */private GameObject streetPassLight;
	[SerializeField]/* 					  */private GameObject spotPassLight;
	[SerializeField]/* 					  */private GameObject batteryLight;
	[SerializeField]/*					  */private AudioSource dsAudioSource;
	[SerializeField]/*					  */private AudioClip[] dsAudioClips;


	void Start(){

		dsIsOpen=true;

		Button theOpenDSButton = openDSButton.GetComponent<Button>();
    	Button theSpinSideDSButton = spinSideDSButton.GetComponent<Button>();

    	theOpenDSButton.onClick.AddListener(openCloseDSFunction);
    	theSpinSideDSButton.onClick.AddListener(spinSideFunction);

    	Button theCameraSwitch = dsSwitchCamera.GetComponent<Button>();
    	theCameraSwitch.onClick.AddListener(dsCameraSwitchFunction);

    	Button theDSStreetPassButton = dsStreetPassButton.GetComponent<Button>();
    	theDSStreetPassButton.onClick.AddListener(initiateStreetPass);
    	Button theDSSpotPassButton = dsSpotPassButton.GetComponent<Button>();
    	theDSSpotPassButton.onClick.AddListener(initiateSpotPass);
    	Button theBatteryButton = dsBatteryButton.GetComponent<Button>();
    	theBatteryButton.onClick.AddListener(initiateBatteryLight);


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

	void initiateStreetPass(){
		if(streetPassLight.activeSelf==false){
		streetPassLight.SetActive(true);
		} else { streetPassLight.SetActive(false);}

	}

	void initiateSpotPass(){
		if(spotPassLight.activeSelf==false){
		spotPassLight.SetActive(true);
		} else { spotPassLight.SetActive(false);}


	}

	void initiateBatteryLight(){

		


	}

	void openCloseDSFunction(){

		if  (dsIsOpen){
				dsAudioSource.PlayOneShot(dsAudioClips[0]);
				dsAnimation.SetTrigger("seeYouOnTheFlippityFlip"); dsIsOpen=false;
				//dsAudioSource.PlayOneShot(dsAudioClips[0]);
			}
		else {
				dsAudioSource.PlayOneShot(dsAudioClips[0]);
				dsAnimation.SetTrigger("seeYouOnTheFlippityFlop"); dsIsOpen=true;
				//dsAudioSource.PlayOneShot(dsAudioClips[0]);
			}


	}

	void spinSideFunction(){

		dsAnimation.SetTrigger("spinSide");


	}

	void Update(){




	}



}
