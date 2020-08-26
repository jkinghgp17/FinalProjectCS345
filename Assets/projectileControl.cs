using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileControl : MonoBehaviour
{
	public Transform target;
	public float speed;
	public GameObject player;


	// Start is called before the first frame update
	void Start()
	{
		speed = 2.0f;
		player = GameObject.FindWithTag("Player");
		target = player.transform;
	}

	// Update is called once per frame
	void Update()
	{
		player = GameObject.FindWithTag("Player");
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		if (Vector3.Distance(transform.position, player.transform.position) < 0.001f)
		{
			// Swap the position of the cylinder.
			Debug.Log("I hit you");
			Destroy(this.gameObject);
		}
	}
}
