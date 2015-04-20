using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeImageColor : MonoBehaviour {

	Image image;
	void Start()
	{
		image = GetComponent<Image>();

	}

	public void Rotate()
	{
		transform.Rotate(0,0,-3f);
	}

	void Update()
	{

	}

}
