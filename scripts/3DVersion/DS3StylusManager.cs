using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DS3StylusManager : MonoBehaviour
{
    
    void Start()
    {

    }

    void Update()
    {

            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + 60f, Input.mousePosition.y + 50f, distance_to_screen));

    }



}
