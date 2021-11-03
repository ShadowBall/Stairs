using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource TinyBlocks;
    public AudioSource TinyBlocksReversed;
    public GameObject spawn;
    public SpawnPlatform sp;
    private bool musicchanged = false;

    void Start()
    {
        GameObject spawn = GameObject.Find("SpawnPoint");
        sp = spawn.GetComponent<SpawnPlatform>();
        AudioSource[] music = GetComponents<AudioSource>();
        TinyBlocks = music[0];
        TinyBlocksReversed = music[1];
    }

    // Update is called once per frame
    void Update()
    {
        GameObject spawn = GameObject.Find("SpawnPoint");
        sp = spawn.GetComponent<SpawnPlatform>();
        if (sp.crystaltaken == true && musicchanged == false)
        {
            TinyBlocks.Pause();
            TinyBlocksReversed.Play();
            musicchanged = true;
        }
        if (sp.crystaltaken == false && musicchanged == true)
        {
            TinyBlocksReversed.Pause();
            TinyBlocks.Play();
            musicchanged = false;
        }
    }
}
