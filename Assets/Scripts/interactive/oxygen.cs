using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oxygen : MonoBehaviour, tool
{
    public tools type { get; set; }
    public float value { get; set; }
    Coroutine co;
    Outline outline;

    public AudioClip air;
    AudioSource audioS;

    private IEnumerator off()
    {
        yield return new WaitForSeconds(2.0f);
        outline.enabled = false;
    
    }

    public void action()
    {
        if(co != null){
            StopCoroutine(co);
        }
        outline.enabled = true;
        co = StartCoroutine(off());

    }

    public void interact(){
        audioS.PlayOneShot(air);
    }
    public float oxigen;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        type = tools.oxigen;
        value = oxigen;
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
