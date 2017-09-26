using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateAgent : Agent {

  private GameObject top;
  private Gameobject stylus;
  private GameObject topScreenBackLight;
  private GameObject bottomScreenBackLight;
  public  float      screenOnOff;

	public override List<float> CollectState()
	{
		List<float> state = new List<float>();
    		state.Add(stylus.transform.position);
    		state.Add(top.transform.position.z);
    		state.Add(screenOnOff = 0f);
    
		return state;
	}

	public override void AgentStep(float[] act)
	{

	}

	public override void AgentReset()
	{

	}

	public override void AgentOnDone()
	{

	}
}
