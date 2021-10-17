using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawn;
    void Start()
    {
        spawn = GameObject.Find("SpawnPoint");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject != null)
        {
            //sp.parachuteappeared = false;
            Destroy(gameObject);
            spawn.GetComponent<SpawnPlatform>().parachuteappeared = false;
            spawn.GetComponent<SpawnPlatform>().parachutetaken = true;

        }
    }
}
