using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScrollingBg : MonoBehaviour
{
	public Transform[] background;
	public Transform[] urutanSpawn;
	private Vector3 direction;
	public float speed;

	// Start is called before the first frame update
	void Start()
	{
		urutanSpawn[0] = Instantiate(background[Random.Range(0, 3)], new Vector3(0, 0, 0), Quaternion.identity, this.transform).transform;
		urutanSpawn[1] = Instantiate(background[Random.Range(0, 3)], new Vector3(0, 10, 0), Quaternion.identity, this.transform).transform;
		direction = new Vector3(0,-1,0);
	}

	// Update is called once per frame
	void Update()
	{
		positionUpdate();
		checkPosition();
	}

	private void checkPosition()
	{
		if (urutanSpawn[0].position.y <= -10f){
			Destroy(urutanSpawn[0].gameObject);
			urutanSpawn[0] = Instantiate(background[Random.Range(0, 3)], new Vector3(0, 0, 0), Quaternion.identity, this.transform).transform;
			urutanSpawn[0].position = urutanSpawn[1].position + new Vector3(0, 10, 0);

		}
		if (urutanSpawn[1].position.y <= -10f){
			Destroy(urutanSpawn[1].gameObject);
			urutanSpawn[1] = Instantiate(background[Random.Range(0, 3)], new Vector3(0, 10, 0), Quaternion.identity, this.transform).transform;
			urutanSpawn[1].position = urutanSpawn[0].position + new Vector3(0, 10, 0);
		}
	}

	private void moveToTop(int index)
	{
		if (index == 0){
			background[0].position = background[1].position + new Vector3(0, 10, 0);
		} 
		else if (index == 1){
			background[1].position = background[0].position + new Vector3(0, 10, 0);
		}
	}

	private void positionUpdate()
	{
		urutanSpawn[0].position += direction * Time.deltaTime * speed;
		urutanSpawn[1].position += direction * Time.deltaTime * speed;
	}
}