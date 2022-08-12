using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
	private Vector3 direction;
	public float speed;

	void Start()
    {
        
    }

    void Update()
    {
		updatePosition();
    }

	private void updatePosition()
	{
		transform.position = getNextPosition();
	}
	public Vector3 getNextPosition()
	{
		return transform.position + newPosition();
	}
	public Vector3 newPosition()
	{
		return direction * Time.deltaTime * speed;
	}
	internal void SetXDirection(float v)
	{
		direction.x = v;
	}
	internal void SetYDirection(float v)
	{
		direction.y = v;
	}
	public void setDirection(Vector3 value)
	{
		direction = value;
	}
	public void setDirection(Vector2 value)
	{
		direction.x = value.x;
		direction.y = value.y;
	}
	internal void setDirection(float x, float y)
	{
		direction.x = x;
		direction.y = y;
	}
}
