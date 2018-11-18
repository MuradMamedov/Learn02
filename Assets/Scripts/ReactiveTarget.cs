using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private SceneController _parent;

    void Start()
    {

    }

    void Update()
    {

    }

    internal void ReactToHit()
    {
        var behavior = GetComponent<WanderingAI>();
        if(behavior != null)
        {
            behavior.Die();
        }

        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);
        _parent.RemoveChild(gameObject);
        Destroy(gameObject);
    }

    public void Register(SceneController sceneController)
    {
        _parent = sceneController;
    }
}
