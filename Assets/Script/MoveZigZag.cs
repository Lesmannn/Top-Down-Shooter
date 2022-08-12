using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZigZag : MonoBehaviour
{
	public Vector2 startWait;
	public float dodge;
	public Vector2 manuverWait;
	public Vector2 manuverTime;
	private float targetManuver;
	private Rigidbody2D rb;
	public float smoothing;
	private float currentSpeed;
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Evade());
		rb = GetComponent<Rigidbody2D>();

	}

	IEnumerator Evade()
	{
		yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
		while (true)
		{
			targetManuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
			yield return new WaitForSeconds(Random.Range(manuverTime.x, manuverTime.y));
			targetManuver = 0;
			yield return new WaitForSeconds(Random.Range(manuverWait.x, manuverWait.y));
		}

	}

	private void FixedUpdate()
	{
		float newManuver = Mathf.MoveTowards(rb.velocity.x, targetManuver, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newManuver, 0.0f, currentSpeed);
		rb.position = new Vector3 (rb.position.x, 5.52f, rb.position.y);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
