﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Displays selection when clicking an object
/// </summary>
public class SelectObject : MonoBehaviour {

    public GameObject SelectionPrefab;
    private GameObject selectionInstance;
    public static GameObject SelectedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {     
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            if (SelectedObject != gameObject && Physics.Raycast(ray, out hit))
            {
                selectionInstance = Instantiate(SelectionPrefab);
                selectionInstance.transform.SetParent(transform);
                selectionInstance.transform.localPosition = Vector3.zero;
                SelectedObject = gameObject;
            }
            else
            {
                if (SelectedObject == gameObject)
                {
                    SelectedObject = null;
                }
                Destroy(selectionInstance);
            }
        }
    }
}