using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerCharacter>();
        if(player != null)
        {
            player.Hurt(damage);
        }
        Destroy(gameObject);
    }
}
