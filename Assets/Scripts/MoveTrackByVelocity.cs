using UnityEngine;
using System.Collections;

public class MoveTrackByVelocity : MonoBehaviour
{
	private Vector2 position;
	private float speed = -20f;

	void Awake ()
	{
		position = Vector2.zero;
		position.y = speed;
	}

	void FixedUpdate ()
	{
		rigidbody2D.velocity = position;
	}

}
