using UnityEngine;
using System.Collections;

public class ManageTracks : MonoBehaviour
{
	private TrackCollection trackCollectionScript;

	void Start(){
		trackCollectionScript =GameObject.Find ("GameController").GetComponent<TrackCollection> ();
	}

	void OnTriggerEnter2D (Collider2D otherCollider)
	{
		if (otherCollider.CompareTag (Constants.TAG_CAR)) {
			trackCollectionScript.RecycleTrack(gameObject);
		}
	}

}
