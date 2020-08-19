using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControl : MonoBehaviour
{
	public int stage;
	public int lastStage;
	public float timer = 7.0f;
	private float waitTime = 7.0f;
	public int lowStage = 0;
	public int highStage = 4;
	public float distance;
	private MeshRenderer meshRenderer;
	public Material TileM;
	public float heightScale = 3.0f;

	// Start is called before the first frame update
	void Start()
    {
		distance = 0;
		stage = 1;
		lastStage = 1;
		meshRenderer = GetComponent<MeshRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
		if (timer >= waitTime)
		{
			lastStage = stage;
			Debug.Log("I need a change");
			stage = Random.Range(lowStage, highStage);
			timer = 0.0f;
			distance = (float)stage - lastStage;
		}

		if (distance > 0.0f)
		{
			this.transform.Translate(0, heightScale*Time.deltaTime, 0);
			distance -= Time.deltaTime;
		}

		if (distance < 0.0f)
		{
			this.transform.Translate(0, -heightScale * Time.deltaTime, 0);
			distance += Time.deltaTime;
		}

		switch (stage)
		{
			case 0:
				TileM = Resources.Load<Material>("MS0");
				meshRenderer.material = TileM;
				Debug.Log("case 0");
				break;

			case 1:
				TileM = Resources.Load<Material>("MS1");
				meshRenderer.material = TileM;
				Debug.Log("case 1");
				break;

			case 2:
				TileM = Resources.Load<Material>("MS2");
				meshRenderer.material = TileM;
				Debug.Log("case 2");
				break;

			case 3:
				TileM = Resources.Load<Material>("MS3");
				meshRenderer.material = TileM;
				Debug.Log("case 3");
				break;

			default:
				Debug.Log("This is a bug, we should have value in stage");
				break;
		}
    }
}
