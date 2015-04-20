using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CubeControl : MonoBehaviour {

	public Slider slider;
	public float move;

	// Use this for initialization
	void Start () {

		move = this.transform.position.x;


	}
	
	// Update is called once per frame
	void Update () {
		slider.value = transform.position.x;
	}
}
