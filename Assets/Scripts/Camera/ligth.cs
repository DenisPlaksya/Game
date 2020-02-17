using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ligth : MonoBehaviour
{
    public TrailRenderer player;
    public cam c;
    public Light point;
    public Color[] colorsForPoint;
    public int tmp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TrailRenderer>();
        StartCoroutine(str());
    }

    void RandomColor()
    {
        //point.color = colorsForPoint[c.rand];//Random.Range(0, colorsForPoint.Length)
    }

    IEnumerator str()
    {
        yield return new WaitForSeconds(0.00001f);
        c = GameObject.FindGameObjectWithTag("Cam").GetComponent<cam>();//
        point = GetComponent<Light>();
        point.color = colorsForPoint[c.rand];
        player.material.color = colorsForPoint[c.rand];
        Debug.Log(c.rand);
    }
}
