using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class machineSignal : MonoBehaviour, tool
{
    public tools type { get; set; }
    public float value { get; set; }

    public Text message;
    Coroutine co;
    Outline outline;

    bool isRepair = false;


    public AudioClip clip;
    AudioSource audioS;
    private IEnumerator off()
    {
        yield return new WaitForSeconds(2.0f);
        outline.enabled = false;

    }

    public void action()
    {
        if (co != null)
        {
            StopCoroutine(co);
        }
        outline.enabled = true;
        co = StartCoroutine(off());

    }

    public void interact()
    {
        if(!isRepair){
             StartCoroutine(soundAndInactive());
        }
       
    }

    IEnumerator soundAndInactive()
    {
        audioS.PlayOneShot(clip);
        yield return new WaitWhile(() => audioS.isPlaying);
        message.text = "¡Máquina reparada!";
        isRepair = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        outline = GetComponent<Outline>();
        outline.enabled = false;
        type = tools.viking;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
