using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            var ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                var hitObject = hit.transform.gameObject;
                var target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }
    void OnGUI()
    {
        var size = 24;
        float posX = _camera.scaledPixelWidth / 2 - size / 4;
        float posY = _camera.scaledPixelHeight / 2 - size / 4;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }

    private IEnumerator SphereIndicator(Vector3 point)
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = point;

        yield return new WaitForSeconds(1f);
        Destroy(sphere);
    }
}
