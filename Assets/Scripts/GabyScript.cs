using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public float Speed = 5f;
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("Editor");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            camera.transform.eulerAngles += Speed * new Vector3(-Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse X"),0f);
        }
    }
}
