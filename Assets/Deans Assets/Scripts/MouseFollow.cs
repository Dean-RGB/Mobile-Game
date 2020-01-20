using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{

    [SerializeField] private GameObject prefab;

    public void Update ()
    {
        UpdateThisPosition ();

        if (Input.GetMouseButtonDown(0))
            CreateInstance();
    }

    private void UpdateThisPosition ()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }

    private void CreateInstance ()
    {
        Instantiate(prefab, transform.position, Quaternion.identity, transform.parent);
        return;
    }
}
