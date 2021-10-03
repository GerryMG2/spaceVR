using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oxygen : MonoBehaviour,tool
{
    public tools type { get; set; }
    public float value { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        type = tools.oxigen;
        value = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
