﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Single simulation request
/// </summary>
public class Request : MonoBehaviour {

    public float Speed = 1;

    public Transform From;
    public Transform To;

    private float progress = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (To!=null)
        {
            transform.position = Vector3.Lerp(From.position, To.position, progress);
            progress += Time.deltaTime * Speed;
        }
	}

    public void Redirect(Transform to)
    {
        Redirect(To, to);
    }

    public void Redirect(Transform from, Transform to)
    {
        From = from;
        To = to;
        progress = 0;
    }
}
