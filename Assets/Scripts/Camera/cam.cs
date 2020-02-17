using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Camera camer;
    //public Light point;
    public Transform player;
    public Color[] colors;
    public int rand;
    //public Color[] colorsForPoint;
    void Start()
    {
        
        camer = GetComponent<Camera>();
        // point = GetComponent<Light>();
        //cameraRandomColor();
        camer.backgroundColor = colors[cameraRandomColor()];
    }

    public int cameraRandomColor()
    {
        rand = Random.Range(0, 10);
        return rand;
        //ыpoint.color = colorsForPoint[Random.Range(0, colorsForPoint.Length)];
    }
    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
