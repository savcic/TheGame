using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ParticleSystem))]

public class ParticleSortingLayerFix : MonoBehaviour
{
		
		// Use this for initialization
		void Start ()
		{
				SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
				particleSystem.renderer.sortingLayerID = spriteRenderer.sortingLayerID;
				particleSystem.renderer.sortingOrder = spriteRenderer.sortingOrder;
		}
		
}