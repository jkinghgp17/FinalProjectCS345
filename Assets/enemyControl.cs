using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
	public Transform sunrise;
	public Transform sunset;
	public bool firstHalf;

	// Time to move from sunrise to sunset position, in seconds.
	public float journeyTime;

	// The time at which the animation started.
	private float startTime;

	// Start is called before the first frame update
	void Start()
    {
		
		firstHalf = true;
		// Note the time at the start of the animation.
		startTime = Time.time;
		journeyTime = 3.0f;
	}

	// Update is called once per frame
	void Update()
    {
		// The center of the arc
		Vector3 center = (sunrise.position + sunset.position) * 0.5F;

		// move the center a bit downwards to make the arc vertical
		//center -= new Vector3(0, 1, 0);

		// Interpolate over the arc relative to center
		Vector3 riseRelCenter = sunrise.position - center;
		Vector3 setRelCenter = sunset.position - center;

		// The fraction of the animation that has happened so far is
		// equal to the elapsed time divided by the desired time for
		// the total journey.
		float fracComplete = (Time.time - startTime) / journeyTime;
		//riseRelCenter

		if (firstHalf)
		{
			transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
		}
		else
		{
			transform.position = Vector3.Slerp(setRelCenter, riseRelCenter, fracComplete);
		}
		transform.position += center;

		if (fracComplete >= 1.0f)
		{
			startTime = Time.time;
			firstHalf = !firstHalf;
		}


	}
}
