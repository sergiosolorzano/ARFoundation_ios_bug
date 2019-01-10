using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;

public class Transverse : MonoBehaviour {

    public GameObject[] Art = new GameObject[7];
    
    Camera cam;

    //applicable to the first time the Art Menu is shown only
    public void Start()
    {
        cam = Camera.main;
        GameObject.FindWithTag("MyLight").GetComponent<Light>().intensity = 1.2f;

        for (int i = 0; i < Art.Length; i++)
        {
            TraverseOnOffMeshRenderer(Art[i]);
        }
    }

    void TraverseOnOffMeshRenderer(GameObject obj)
    {
        if (obj.GetComponent<MeshRenderer>() != null)
        {
            obj.GetComponent<MeshRenderer>().enabled = !obj.GetComponent<MeshRenderer>().enabled;

            foreach (Transform child in obj.transform)
            {
                TraverseOnOffMeshRenderer(child.gameObject);
            }
        }
    }

    void TraverseOnOffCollider(GameObject obj)
    {
        if (obj.GetComponent<BoxCollider>() != null)
        {
            obj.GetComponent<BoxCollider>().enabled = !obj.GetComponent<BoxCollider>().enabled;
            foreach (Transform child in obj.transform)
            {
                TraverseOnOffCollider(child.gameObject);
            }
        }
    }
}
