using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour, tool
{
    public tools type { get; set; }
    public float value { get; set; }
    Coroutine co;
    Outline outline;

    
    public AudioClip clip;
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
        
        StartCoroutine(soundAndInactive());
    }

    IEnumerator soundAndInactive(){
        audioS.PlayOneShot(clip);
        yield return new WaitWhile(() => audioS.isPlaying);
        GetComponent<Transform>().gameObject.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        audioS = GetComponent<AudioSource>();
        type = tools.hammer;
        
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
