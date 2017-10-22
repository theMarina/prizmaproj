using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {
	public float repeatRateSec;
	public string objectsTag;
    public Camera camLeft;
    public Camera camRight;

    GameObject[] myArr;
    int myIter=0;

	// Use this for initialization
	void Start () {
        myArr = GameObject.FindGameObjectsWithTag(objectsTag);

        //hide all objects
        foreach (GameObject o in myArr){
			o.SetActive (false);
		}

        // flip cameras
        camLeft.projectionMatrix = camLeft.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
        camRight.projectionMatrix = camRight.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));

        myArr [myIter].SetActive (true);
		InvokeRepeating("showNextAnim",repeatRateSec,repeatRateSec);
	}

	void showNextAnim(){
		myArr [myIter].SetActive (false);		//set current animation object to false

		myIter++;
		if (myIter == myArr.Length) {			//loop on all object array
			myIter = 0;
		}

		myArr [myIter].SetActive (true);		//set next animation object to true
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
