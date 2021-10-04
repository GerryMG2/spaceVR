//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    public float _maxDistance = 10;
    private GameObject _gazedAtObject = null;
    LayerMask Ground;
    LayerMask Tools;

    public bool hasHammer;
    public Text oxigen;
    public float oxi = 350;
    float oxiInitial;
    public float oxigen_delta = 0.001f;

    public InputManager input;
    public GameObject Mark;
    public GameObject Player;

    float aux;

    void addOxige(float ad)
    {
        oxi += ad;
        if (oxi >= 500)
        {
            oxi = 500;
        }
    }

    public void Start()
    {
        Ground = 1 << 8;
        Tools = 1 << 7;
        oxiInitial = oxi;

    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        oxi -= Time.deltaTime;
        aux = oxi / oxiInitial * 100;
        aux = Mathf.Round(aux);
        oxigen.text = "Oxigeno " + aux + " %";


        RaycastHit hitT;
        if (Physics.Raycast(transform.position, transform.forward, out hitT, _maxDistance / 2, Tools))
        {

            // GameObject detected in front of the camera.
            if (hitT.transform.GetComponent<tool>() != null)
            {
                if (hitT.transform.GetComponent<tool>().type == tools.oxigen)
                {
                    hitT.transform.GetComponent<tool>().action();
                    if (input.IsTriggerPressed())
                    {
                        hitT.transform.GetComponent<tool>().interact();
                        addOxige(hitT.transform.GetComponent<tool>().value);
                    }
                }

                if (hitT.transform.GetComponent<tool>().type == tools.hammer)
                {
                    
                    hitT.transform.GetComponent<tool>().action();
                    if (input.IsTriggerPressed())
                    {
                        hitT.transform.GetComponent<tool>().interact();
                        hasHammer = true;
                    }
                }

                if (hitT.transform.GetComponent<tool>().type == tools.viking)
                {
                    
                    hitT.transform.GetComponent<tool>().action();
                    if (input.IsTriggerPressed() && hasHammer)
                    {
                        hitT.transform.GetComponent<tool>().interact();
                        
                    }
                }

            }
        }
        else
        {
            RaycastHit hitGround;
            if (Physics.Raycast(transform.position, transform.forward, out hitGround, _maxDistance, Ground))
            {
                if (hitGround.transform.GetComponent<Terrain>() != null)
                {
                    Mark.SetActive(true);
                    Vector3 NewMarkPosition = new Vector3(hitGround.point.x, hitGround.point.y + 0.5f, hitGround.point.z);
                    Mark.transform.position = NewMarkPosition;
                    Vector3 newTransformPosition = new Vector3(hitGround.point.x, hitGround.point.y + 2f, hitGround.point.z);

                    // GameObject detected in front of the camera.
                    if (input.IsTriggerPressed())
                    {
                        Mark.SetActive(false);
                        Player.transform.position = newTransformPosition;

                    }
                }
                else
                {
                    Mark.SetActive(false);
                }

            }
            else
            {
                Mark.SetActive(false);
            }
        }






        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
    }
}
