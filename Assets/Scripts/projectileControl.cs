using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileControl : MonoBehaviour
{
	public Transform target;
	public float speed;
	public GameObject player;
	public HealthCounter hc;
	

	// Start is called before the first frame update
	void Start()
	{
		speed = 2.0f;
		player = GameObject.FindWithTag("Player");
		target = player.transform;
		hc = player.GetComponent<HealthCounter>();

	}

	// Update is called once per frame
	void Update()
	{
		player = GameObject.FindWithTag("Player");
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		if (Vector3.Distance(transform.position, player.transform.position) < 2.0f)
		{
			// Swap the position of the cylinder.
			Debug.Log("I hit you");
			hc.curHealth--;
			Destroy(this.gameObject);
		}
			
	}
}
