using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class OOB_Marker : OOB_Object
{
    public AudioClip audioClip;
    public UnityEvent onTriggerEvent;

    private AudioSource audioSource;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (OOB_Manager.instance != null)
            OOB_Manager.instance.AddOOBObject(this);

        ToggleObjectShown(false);
    }

    public void TriggerMarker()
    {
        if(SoundManager.instance != null && audioClip != null)
            SoundManager.instance.PlayEffectOneShot(audioClip);

        onTriggerEvent?.Invoke();
    }
}
