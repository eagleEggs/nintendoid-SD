using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DSManagement : MonoBehaviour {

	[SerializeField]/* 					  */public 	GameObject 		ds;
	[SerializeField]/* 					  */public 	GameObject 		dsTop;
	[SerializeField]/* 					  */public 	GameObject 		dsTopParent;
	[SerializeField]/* 					  */public 	GameObject 		dsBottom;
	[SerializeField]/* 					  */public 	Animator 		dsAnimation;
	[SerializeField]/* 					  */public 	Material		dsMaterial;
	[SerializeField]/* 					  */private bool 			dsIsOpen;
	[SerializeField]/* 					  */private bool 			dsIsClosed;
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
	[SerializeField]/* 					  */private Button 			blueButton;
	[SerializeField]/* 					  */private Button 			goldButton;
	[SerializeField]/* 					  */private Button 			blackButton;
	[SerializeField]/* 					  */private Button 			redButton;
	[SerializeField]/* 					  */private Button 			pinkButton;
	[SerializeField]/* 					  */private Button 			yellowButton;
	[SerializeField]/* 					  */private Button 			greenButton;
	[SerializeField]/* 					  */private Button 			whiteButton;
	[SerializeField]/* 					  */private Button 			randomButton;
	[SerializeField]/* 					  */private Button 			matteButton;
	[SerializeField]/* 					  */private Button 			glossButton;
	[SerializeField]/* 					  */private Slider 			rotateSlider;
	[SerializeField]/* 					  */private float 			rotateSliderAmount;
	[SerializeField]/* 					  */private float 			topSliderAmount;
	[SerializeField]/* 					  */private Slider 			topSlider;
	[SerializeField]/* 					  */private Slider 			ds3dSlider;
	[SerializeField]/* 					  */private float 			ds3dSliderAmount;
	[SerializeField]/* 					  */private Camera 			ds3dCamera;
	[SerializeField]/* 					  */private Camera 			dsSideCamera;
	[SerializeField]/* 					  */private Camera 			dsFrontCamera;
	[SerializeField]/* 					  */private Camera 			dsCloseCamera;
	[SerializeField]/* 					  */private GameObject streetPassLight;
	[SerializeField]/* 					  */private GameObject spotPassLight;
	[SerializeField]/* 					  */private GameObject batteryLight;
	[SerializeField]/* 					  */private GameObject networkLight;
	[SerializeField]/*					  */private AudioSource dsAudioSource;
	[SerializeField]/*					  */private AudioClip[] dsAudioClips;
	[SerializeField]/*					  */private Material glossShader;
	[SerializeField]/*					  */private Material matteShader;
	private float randomFlickerCount=1;
	private bool lowBattery=false;
	private bool ds3dOn = false;


	void Start(){

		dsIsOpen=true;
		dsIsClosed=false;
		ds3dSlider.maxValue = 20;
		ds3dSlider.minValue = 0f;

		StartCoroutine(networkLighting());

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

    	//Button theBatteryButton = dsBatteryButton.GetComponent<Button>();
    	//theBatteryButton.onClick.AddListener(initiateBatteryLight);


    	/* color system */

    	Button theBlueButton = blueButton.GetComponent<Button>();
    	theBlueButton.onClick.AddListener(dsChangeColorBlue);

    	Button theRedButton = redButton.GetComponent<Button>();
    	theRedButton.onClick.AddListener(dsChangeColorRed);

    	Button theBlackButton = blackButton.GetComponent<Button>();
    	theBlackButton.onClick.AddListener(dsChangeColorBlack);

    	Button theGoldButton = goldButton.GetComponent<Button>();
    	theGoldButton.onClick.AddListener(dsChangeColorGold);

    	Button thePinkButton = pinkButton.GetComponent<Button>();
    	thePinkButton.onClick.AddListener(dsChangeColorPink);

    	Button theYellowButton = yellowButton.GetComponent<Button>();
    	theYellowButton.onClick.AddListener(dsChangeColorYellow);

    	Button theGreenButton = greenButton.GetComponent<Button>();
    	theGreenButton.onClick.AddListener(dsChangeColorGreen);

    	Button theWhiteButton = whiteButton.GetComponent<Button>();
    	theWhiteButton.onClick.AddListener(dsChangeColorWhite);

    	Button theRandomButton = randomButton.GetComponent<Button>();
    	theRandomButton.onClick.AddListener(dsChangeColorRandom);

    	/* shader control */
    	Button theMatteButton = matteButton.GetComponent<Button>();
    	theMatteButton.onClick.AddListener(dsChangeShaderMatte);

    	Button theGlossButton = glossButton.GetComponent<Button>();
    	theGlossButton.onClick.AddListener(dsChangeShaderGloss);


	}



	IEnumerator networkLighting(){

		while(true && lowBattery==false){
		
		randomFlickerCount = Random.Range(0.1f, 0.69f);

		if (networkLight.activeSelf==true){
		networkLight.SetActive(false);
		yield return new WaitForSeconds(randomFlickerCount);
		Debug.Log("Was On");}
		else{networkLight.SetActive(true);
			Debug.Log("Turning On");
			yield return new WaitForSeconds(randomFlickerCount);}
		}
	}


	void dsChangeShaderMatte(){

		Debug.Log("Changing Shader to Matte");
		//dsMaterial = matteShader;

	}

	void dsChangeShaderGloss(){

		Debug.Log("Changing Shader to Gloss");
		//dsMaterial = glossShader;

	}

	void dsChangeColorBlue(){

			Debug.Log("Changing Color to Blue");
			dsMaterial.SetColor("_Color", Color.blue);
			dsMaterial.SetColor("_EmissionColor", Color.blue);

			//dsMaterial.material.SetColor("_Color", Color.blue);

	}

	void dsChangeColorRed(){


			Debug.Log("Changing Color to Red");
			dsMaterial.SetColor("_Color", Color.red);
			dsMaterial.SetColor("_EmissionColor", Color.red);

	}
		void dsChangeColorGold(){


			Debug.Log("Changing Color to Yellow");
			dsMaterial.SetColor("_Color", Color.yellow);
			dsMaterial.SetColor("_EmissionColor", Color.yellow);
	}

		void dsChangeColorBlack(){


			Debug.Log("Changing Color to Black");
			dsMaterial.SetColor("_Color", Color.black);
			dsMaterial.SetColor("_EmissionColor", Color.black);
	}

		void dsChangeColorPink(){


			Debug.Log("Changing Color to Pink");
			dsMaterial.SetColor("_Color", new Color(1, 0, 1, 1));
			dsMaterial.SetColor("_EmissionColor", new Color(1, 0, 1, 1));
	}

		void dsChangeColorYellow(){


			Debug.Log("Changing Color to Yellow");
			dsMaterial.SetColor("_Color", Color.yellow);
			dsMaterial.SetColor("_EmissionColor", Color.yellow);
	}

		void dsChangeColorGreen(){


			Debug.Log("Changing Color to Green");
			dsMaterial.SetColor("_Color", Color.green);
			dsMaterial.SetColor("_EmissionColor", Color.green);
	}

		void dsChangeColorWhite(){


			Debug.Log("Changing Color to White");
			dsMaterial.SetColor("_Color", Color.white);
			dsMaterial.SetColor("_EmissionColor", Color.white);
	}

		void dsChangeColorRandom(){


			Debug.Log("Changing Color to White");
			dsMaterial.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
			dsMaterial.SetColor("_EmissionColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
			//Debug.Log(randomColorName);
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
		if(batteryLight.activeSelf==false){
		batteryLight.SetActive(true);
		} else { batteryLight.SetActive(false);}



	}

	void openCloseDSFunction(){

		if  (dsIsOpen){
				dsAudioSource.PlayOneShot(dsAudioClips[0]);
				dsAnimation.SetTrigger("seeYouOnTheFlippityFlip"); dsIsOpen=false;
				spotPassLight.SetActive(true);
				dsIsOpen=false;
				dsIsClosed=true;
				//dsAudioSource.PlayOneShot(dsAudioClips[0]);
			}
		else {
				if (dsIsClosed){
				dsAudioSource.PlayOneShot(dsAudioClips[0]);
				dsAnimation.SetTrigger("seeYouOnTheFlippityFlop"); dsIsOpen=true;
				spotPassLight.SetActive(false);
				dsIsOpen=true;
				dsIsClosed=false;
			}
				//dsAudioSource.PlayOneShot(dsAudioClips[0]);
			}


	}

	void spinSideFunction(){

		dsAnimation.SetTrigger("spinSide");


	}

	void Update(){

		rotateSliderAmount = rotateSlider.value;
		ds.transform.rotation = Quaternion.Euler(0, rotateSliderAmount * 360, 0);

		topSliderAmount = topSlider.value;
		dsTop.transform.rotation = Quaternion.Euler(0, 0, 180);

		ds3dSliderAmount = ds3dSlider.value;
		ds3dCamera.fieldOfView = ds3dSliderAmount + 60;


	}



}
