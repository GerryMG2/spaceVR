using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public bool IsTriggerPressed()
    {
        return Google.XR.Cardboard.Api.IsTriggerPressed;
        
    }
   
}
