using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]

public class Player : MonoBehaviour
{
	public InputHandler inputHandler;
    private Moveable moveable;

	void Awake()
	{
		moveable = GetComponent<Moveable>();
	}
		
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnKey(Vector2 direction)
	{
		moveable.setDirection(direction);
	}
	private void OnEnable()
	{
		inputHandler.OnKeyAction += OnKey;
	}
	private void OnDisable()
	{
		inputHandler.OnKeyAction -= OnKey;
	}
}
