using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private CharacterController _characterController;
	private int _health;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
		_health = 5;
    }
	public void Hurt(int damage)
	{
		_health -= damage;
		if(_health < 0)
		{
			Reset();
		}
	}

    private void Reset()
    {
		_characterController.transform.position = new Vector3(0, 1.5f, -25f);
		_health = 5;
    }

    void Update()
    {
    }
}
