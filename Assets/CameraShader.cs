using UnityEngine;
using System.Collections;

public class CameraShader : MonoBehaviour {

	public Shader heatVisionShader;



	void Example() {
		camera.RenderWithShader(heatVisionShader, "VisibleWithHeatVision");

	}
}
	
