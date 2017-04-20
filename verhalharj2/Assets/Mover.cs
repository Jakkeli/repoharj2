using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
        transform.Rotate(0, 1, 0);
        transform.Translate(0.1f, 0, 0);
	}
}
