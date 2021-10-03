using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public bool IsTriggerPressed()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            return Input.GetMouseButtonDown(0);
        }
        return Google.XR.Cardboard.Api.IsTriggerPressed;

    }

    public bool otherBtn(){
        return Google.XR.Cardboard.Api.IsTriggerHeldPressed;
    }

}
