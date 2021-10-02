using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSky : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed;
    void Start()
    {
        Debug.Log("inicia rotation");
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
