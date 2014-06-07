using UnityEngine;
using System.Collections;

public class TrackCollection : MonoBehaviour
{
	public GameObject[] tracks;

	void Awake ()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		CreateTracksPool ();
		AllocateTrack (Vector3.zero);
	}

	private void CreateTracksPool ()
	{
		foreach (GameObject eachTrack in tracks) {
			eachTrack.GetComponent<Track> ().CreatePool ();
		}
	}

	public void AllocateTrack (Vector3 position)
	{
		int trackId = Random.Range (0, 3);
		Track trackScript = tracks [trackId].GetComponent<Track> ().Spawn (position);
		GameManager.Instance.AllocatedTrackList.Add (trackScript.gameObject);
	}

	public void RecycleTrack (GameObject trackObject)
	{
		if (GameManager.Instance.AllocatedTrackList.Count > 1) 
			RemoveTrack ();
		GenerateTrack (trackObject);
	}

	private void RemoveTrack ()
	{
		GameObject trackGroupObject = GameManager.Instance.AllocatedTrackList [0];
		trackGroupObject.GetComponent<Track> ().Recycle ();
		GameManager.Instance.AllocatedTrackList.Remove (trackGroupObject);
	}

	private void GenerateTrack (GameObject trackObject)
	{
		Transform parentTransform = trackObject.transform.parent;
		GameObject parentObject = parentTransform.gameObject;
		Vector3 trackPosition = parentObject.transform.position;
		trackPosition.y += Constants.TRACK_LENGTH;
		AllocateTrack (trackPosition);
	}
}
