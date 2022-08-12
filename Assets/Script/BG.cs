using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
	public Transform[] background;
	private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
		direction = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
		positionUpdate();
		checkPosition();
    }

	public void positionUpdate()
	{
		background[0].position += direction * Time.deltaTime;
		background[1].position += direction * Time.deltaTime;
		background[2].position += direction * Time.deltaTime;
	}
	public void checkPosition()
	{
		if (background[0].position.y <= -20)
		{
			MoveToTop(0);
		}
		if (background[1].position.y <= -20)
		{
			MoveToTop(1);
		}
		if (background[2].position.y <= -20)
		{
			MoveToTop(2);
		}
	}
	public void MoveToTop(int index)
	{
		if (index==0)
		{
			background[0].position = background[2].position + new Vector3(0, 20, 0);
		}
		else if (index==1)
		{
			background[1].position = background[0].position + new Vector3(0, 0, 0);
		}
		else if (index==2)
		{
			background[2].position = background[1].position + new Vector3(0, 10, 0);
		}
	}
}
