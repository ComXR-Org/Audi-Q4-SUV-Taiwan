using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyDomeTest : MonoBehaviour {
	[System.Serializable]
	public class SampleSet
	{
		public GameObject dome;
		public Material skybox;
	}
	public ReflectionProbe reflectionProbe;
	public SampleSet[] sampleSets;
	public Transform lightRoot;
	int index = 0;
	public bool gui;
	void Update () {
		setSky (index);
		lightRoot.localRotation=Quaternion.Euler(0,Time.deltaTime*90,0)* lightRoot.localRotation;
		if(Input.GetKeyDown(KeyCode.Space)){
			index = (index+1)%sampleSets.Length ;
			setSky (index);
		}
	}

	void OnGUI(){
		if(gui){
			if(GUI.Button(new Rect(0,0,200,50),"Trigger")){
				index = (index+1)%sampleSets.Length ;
				setSky (index);
			}
		}
	}
	void setSky(int num){
		for(int i = 0 ; i< sampleSets.Length ; i++){
			sampleSets[i].dome.SetActive(i==num);
		}
		RenderSettings.skybox = sampleSets[num].skybox;

		reflectionProbe.RenderProbe ();
	}
}
