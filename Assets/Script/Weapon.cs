using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public float fireRate;
	public List<float> fireRateModifiers;
	private float timer = 0;
	public PoolObjectType type;
    // Start is called before the first frame update
    void Awake()
    {
		fireRateModifiers = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
		timer = timer - Time.deltaTime > 0 ? timer - Time.deltaTime : 0f;
    }

	internal void addFireRateModifier(float modifier)
	{
		fireRateModifiers.Add(modifier);
	}
	internal void removeFireRateModifier(float modifier)
	{
		fireRateModifiers.Remove(modifier);
	}

	public void Shoot()
	{
		if (timer == 0f)
		{
			ObjectPool.GetInstance().requestObject(type).activate(transform.position, transform.rotation);
			timer = fireRate - getFireRateModifier();
		}
	}
	private float getFireRateModifier()
	{
		float mod = 0;

		foreach(float f in fireRateModifiers)
		{
			mod += f;
		}
		return mod;
	}
	internal void clearModifier()
	{
		fireRateModifiers.Clear();
	}
}
