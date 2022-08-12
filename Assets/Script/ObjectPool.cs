	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	public static ObjectPool instance;
	public int size;
	public GameObject[] prefabs;

	[SerializeField]
	private List<PoolObject> poolObject;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
    // Start is called before the first frame update
    void Start()
    {
		InstantiateObject();
    }

	private void InstantiateObject()
	{
		poolObject = new List<PoolObject>();

		for (int i=0; i<size; i++)
		{
			foreach (GameObject go in prefabs)
			{
				poolObject.Add(Instantiate(go, transform).GetComponent<PoolObject>());
			}
		}
	}
	public PoolObject requestObject(PoolObjectType type)
	{
		foreach (PoolObject po in poolObject)
		{
			if (po.type == type && !po.isActive())
			{
				return po;
			}
		}
		return null;
	}
	public static ObjectPool GetInstance()
	{
		return instance;
	}
	public void deactivateAllObject()
	{
		foreach (PoolObject po in poolObject)
		{
			po.deactivate();
		}
	}
}
