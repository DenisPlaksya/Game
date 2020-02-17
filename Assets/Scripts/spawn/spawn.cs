using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] denger;
    public int maxRad;
    public float VertMax = 0;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        for (int i = 0; i < maxRad; i++)
        {
            int rand = Random.Range(0, denger.Length);
            Instantiate(denger[rand], new Vector2(VertMax, 0f), Quaternion.identity);
            VertMax += 3.2f;
        }
    }
}
