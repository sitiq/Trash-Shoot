using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
     public SoundScript[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        foreach(SoundScript s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        PlaySound("bgsound");
    }

    public void PlaySound(string name)
    {
        foreach (SoundScript s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }
    
}
