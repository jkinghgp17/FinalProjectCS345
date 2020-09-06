using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
	public float shootForce;
	public Transform muzzlePoint;
	public GameObject projectile;
	public float projectileLifetime = 5.0f;
	public float fireTime = 1f;
	float timeToFire;
	public int count;
	public GameObject player;
	public Transform cube;
	public Transform backPoint;
	public Transform leftPoint;
	public Transform rightPoint;

	// Start is called before the first frame update
	void Start()
	{
		timeToFire = 0f;
		count = 0;
		projectileLifetime = 6.0f;
	}

	// Update is called once per frame
	void Update()
	{
		player = GameObject.FindWithTag("Player");
		if (Vector3.Distance(player.transform.position, muzzlePoint.position) < Vector3.Distance(player.transform.position, backPoint.position))
		{
			count++;
		}
		if (Vector3.Distance(player.transform.position, muzzlePoint.position) < Vector3.Distance(player.transform.position, leftPoint.position))
		{
			count++;
		}
		if (Vector3.Distance(player.transform.position, muzzlePoint.position) < Vector3.Distance(player.transform.position, rightPoint.position))
		{
			count++;
		}
		//transform.RotateAround(new Vector3(0f, 10f, 0f), new Vector3(0f, 1f, 0f), 1f);
		transform.RotateAround(cube.position, cube.up, 20 * Time.deltaTime);
		timeToFire -= Time.deltaTime;
		if (count == 3 && timeToFire <= 0f)
		{
			GameObject currProjectile = (GameObject)Instantiate(projectile, muzzlePoint.position, muzzlePoint.rotation);
			//currProjectile.GetComponent<Rigidbody>().AddForce(muzzlePoint.up * shootForce);
			Destroy(currProjectile, projectileLifetime);
			timeToFire = fireTime;
		}
		count = 0;
	}
}
