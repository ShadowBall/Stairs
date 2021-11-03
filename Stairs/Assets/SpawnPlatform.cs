using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject> playerobjects = new List<GameObject>();
    private string selectedplayername = "SelectedPlayer";
    public GameObject Background1;
    public GameObject Background2;
    public GameObject Background3;
    public GameObject Background4;
    public GameObject Background5;
    public GameObject Background6;
    public GameObject BackgroundCrystal;
    private int selectedplayer;
    public GameObject obstacle;
    public GameObject gb;
    public GameObject parachute;
    public GameObject crystal;
    GameObject pr;
    GameObject cr;
    public GameOverScript Gmos;
    public AudioSource jumpAudio;
    public AudioSource parachuteAudio;
    public AudioSource reviveAudio;
    public PlayerControls pc;
    public LineTimer lt;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    public Rigidbody2D rb;
    public GameObject grass;
    public bool grassbool = true;
    public bool diedmove = false;
    public float speed;
    private bool m_FacingRight = true;
    public bool move = false;
    public bool parachuteappeared = false;
    public bool crystalappeared = false;
    public bool parachutetaken = false;
    public bool crystaltaken = false;
    // Start is called before the first frame update
    //public List<GameObject> gameobjects = new List<GameObject>();
    //public Vector3[] positions = new Vector3[gameobjects.Count];
    List<GameObject> PlatformList;
    private List<Vector3> positions;
    public float n = 0;
    public int l = 0;
    public int k = 1;
    public int j = 0;
    public int parachuteplatformcounter;
    public int crystalplatformcounter;
    public int scorecounter = 0;
    public int sticheddeathcounter = 0;
    public int stichedrevivecounter = 0;
    public float p = 0f;
    bool jump1 = false;
    bool reversejump1 = false;
   
    void Start()
    {
        SelectCharacter();
        rb = playerobjects[selectedplayer].GetComponent<Rigidbody2D>();
        pc = rb.GetComponent<PlayerControls>();
        AudioSource[] audios = GetComponents<AudioSource>();
        jumpAudio = audios[0];
        parachuteAudio = audios[1];
        reviveAudio = audios[2];
        PlatformList = new List<GameObject>();
        float randomX;

        PlatformList.Add((GameObject)Instantiate(obstacle, transform.position + new Vector3(0,0,0), transform.rotation));
        for (int i = 0; i < 6; i++)

        {
            if (Random.value < 0.5f)
            {
                randomX = -2;
            }
            else
            {
                randomX = 2;
            }
            float randomY = Random.Range(minY, maxY);
            gb = (GameObject)Instantiate(obstacle, transform.position + new Vector3(p + randomX, randomY + n, 0), transform.rotation);
            PlatformList.Add(gb);
            n += 3;              
            j += 1;
            p = PlatformList[j].transform.position.x;
            


        }
    }
    void Update()
    {
        //if (stichedrevivecounter == 1)
        //{
         //   sticheddeathcounter = 2;
        //}
        float step = speed * Time.deltaTime;
        if (move == true)
        {
            if (diedmove == false)
            {
                if (grassbool == true)
                {
                    grass.transform.position = Vector3.MoveTowards(grass.transform.position, new Vector3(grass.transform.position.x, grass.transform.position.y - 5, 0), step);
                    Debug.Log(grass.transform.position);
                    Debug.Log(new Vector3(grass.transform.position.x, grass.transform.position.y - 5, 0));

                }
                float x = PlatformList[k].transform.position.x;
                float y = PlatformList[k].transform.position.y;
                for (int i = 0; i < PlatformList.Count; i++)
                {
              
                    PlatformList[i].transform.localPosition = Vector3.MoveTowards(PlatformList[i].transform.position, new Vector3(PlatformList[i].transform.position.x - x, PlatformList[i].transform.position.y - y, 0), step);
                    float m = rb.transform.position.y - y - 1.34f;

                }
                if (parachuteappeared == true && parachutetaken == false)
                {
                    pr.transform.localPosition = Vector3.MoveTowards(pr.transform.position, new Vector3(PlatformList[parachuteplatformcounter].transform.position.x - x, PlatformList[parachuteplatformcounter].transform.position.y - y + 2.2f, 0), step);
                }
                if (crystalappeared == true && crystaltaken == false)
                {
                    cr.transform.localPosition = Vector3.MoveTowards(cr.transform.position, new Vector3(PlatformList[crystalplatformcounter].transform.position.x - x, PlatformList[crystalplatformcounter].transform.position.y - y + 2.2f, 0), step);
                }


                if (Vector3.Distance(PlatformList[k].transform.position, new Vector3(PlatformList[k].transform.position.x - x, PlatformList[k].transform.position.y - y)) == 0)
                {
                    k += 1;
                    move = false;
                    pc.jumped = false;
                    pc.JumpFun();
                    grassbool = false;
                    if (parachutetaken == true && scorecounter < 20)
                    {                     
                        speed = 30;
                        Spawn();
                        scorecounter += 1;
                        ScoreScript.scoreValue += 1;
                        parachuteappeared = true;
                        pc.parachuted = true;
                        pc.ParachuteFun();
                        lt.timeLeft = 2f;
                        lt.timerBar.fillAmount = 1;
                        Gmos.JumpButton.SetActive(false);
                        Gmos.ReverseJumpButton.SetActive(false);
                    }
                    if(scorecounter == 20)
                    {
                        scorecounter = 0;
                        speed = 15;
                        parachutetaken = false;
                        parachuteappeared = false;
                        pc.parachuted = false;
                        pc.ParachuteFun();
                        lt.timeLeft = 2f;
                        lt.timerBar.fillAmount = 1;
                        Gmos.JumpButton.SetActive(true);
                        Gmos.ReverseJumpButton.SetActive(true);
                    }
                }

            }
            else
            {
                rb.transform.position = Vector3.MoveTowards(rb.transform.position, new Vector3(-PlatformList[k].transform.position.x, PlatformList[k].transform.position.y + 1.34f,0),step);
                Gmos.JumpButton.SetActive(false);
                Gmos.ReverseJumpButton.SetActive(false);
                if (Vector3.Distance(rb.transform.position, new Vector3(-PlatformList[k].transform.position.x, PlatformList[k].transform.position.y + 1.34f)) < 0.1f)
                {
                    move = false;
                    Wait();
                    lt.gameObject.SetActive(false);
                    rb.gravityScale = 0.5f;
                }               
            }
            

        }
        if (move == false)
        {
            if (rb.GetComponent<SpriteRenderer>().flipX == false)
            {
                if (jump1 == true && (rb.transform.position.x - PlatformList[k].transform.position.x) < 0)
                {
                    lt.timeLeft = 2f;
                    lt.timerBar.fillAmount = 1;
                    pc.jumped = true;
                    pc.JumpFun();
                    Spawn();
                    ScoreScript.scoreValue += 1;
                    jump1 = false;
                }
                else if (reversejump1 == true && (rb.transform.position.x - PlatformList[k].transform.position.x) > 0)
                {
                    lt.timeLeft = 2f;
                    lt.timerBar.fillAmount = 1;
                    pc.jumped = true;
                    pc.JumpFun();
                    Spawn();

                    ScoreScript.scoreValue += 1;
                    rb.GetComponent<SpriteRenderer>().flipX = true;
                    reversejump1 = false;
                }
                else if (jump1 == true && (rb.transform.position.x - PlatformList[k].transform.position.x) > 0)
                {
                    pc.died = true;
                    pc.DiedFun();
                    diedmove = true;
                    move = true;
                    jump1 = false;
                }
                else if (reversejump1 == true && (rb.transform.position.x - PlatformList[k].transform.position.x) < 0)
                {
                    pc.died = true;
                    pc.DiedFun();
                    diedmove = true;
                    move = true;
                    reversejump1 = false;
                    rb.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else
            {
                if (jump1 == true && (rb.transform.position.x - PlatformList[k].transform.position.x) > 0)
                {
                    lt.timeLeft = 2f;
                    lt.timerBar.fillAmount = 1;
                    pc.jumped = true;
                    pc.JumpFun();
                    Spawn();

                    ScoreScript.scoreValue += 1;
                    jump1 = false;

                }

                else if (reversejump1 == true && (rb.transform.position.x - PlatformList[k].transform.position.x) < 0)
                {
                    lt.timeLeft = 2f;
                    lt.timerBar.fillAmount = 1;
                    pc.jumped = true;
                    pc.JumpFun();
                    Spawn();
                    ScoreScript.scoreValue += 1;
                    rb.GetComponent<SpriteRenderer>().flipX = false;
                    reversejump1 = false;
                }
                else if (jump1 == true && (rb.transform.position.x - PlatformList[k].transform.position.x) < 0)
                {

                    pc.died = true;
                    pc.DiedFun();
                    diedmove = true;
                    move = true;
                    jump1 = false;
                }
                else if (reversejump1 == true && (rb.transform.position.x - PlatformList[k].transform.position.x) > 0)
                {

                    pc.died = true;
                    pc.DiedFun();
                    diedmove = true;
                    move = true;
                    reversejump1 = false;
                    rb.GetComponent<SpriteRenderer>().flipX = false;
              
                }
            }
        }
        if (sticheddeathcounter == 1 && selectedplayer == 1)
        {
            rb.gravityScale = 0;
            //diedmove = false;
            rb.transform.position = Vector3.MoveTowards(rb.transform.position, new Vector3(0, 0 + 1.34f, 0), step*1.2f);
            if(Vector3.Distance(rb.transform.position, new Vector3(0, 0 + 1.34f,0)) == 0)
            {
                pc.died = false;
                pc.DiedFun();
                lt.gameObject.SetActive(true);
                lt.timeLeft = 2f;
                lt.timerBar.fillAmount = 1;
                Gmos.JumpButton.SetActive(true);
                Gmos.ReverseJumpButton.SetActive(true);
                diedmove = false;
                sticheddeathcounter = 2;
                pc.revive = false;
                pc.ReviveFun();
            }
        }
        if (crystaltaken == true && scorecounter < 30)
        {
            pc.crystaled = true;
            pc.CrystalFun();
            crystalappeared = true;
            BackgroundCrystal.SetActive(true);
            Background1.SetActive(false);
            Background2.SetActive(false);
            Background3.SetActive(false);
            Background4.SetActive(false);
            Background5.SetActive(false);
            Background6.SetActive(false);
        }
        else if (scorecounter == 30)
        {
            BackgroundCrystal.SetActive(false);
            crystaltaken = false;
            crystalappeared = false;
            pc.crystaled = false;
            pc.CrystalFun();
            scorecounter = 0;
        }
        else
        {
            if (ScoreScript.scoreValue < 50)
            {
                Background1.SetActive(true);
            }
            else if (ScoreScript.scoreValue < 100)
            {
                Background1.SetActive(false);
                Background2.SetActive(true);
            }
            else if (ScoreScript.scoreValue < 150)
            {
                Background2.SetActive(false);
                Background3.SetActive(true);
            }
            else if (ScoreScript.scoreValue < 200)
            {
                Background3.SetActive(false);
                Background4.SetActive(true);
            }
            else if (ScoreScript.scoreValue < 250)
            {
                Background4.SetActive(false);
                Background5.SetActive(true);
            }
            else if (ScoreScript.scoreValue < 100000000)
            {
                Background5.SetActive(false);
                Background6.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Spawn()
    {   
        if(crystaltaken == true)
        {  
            ScoreScript.scoreValue += 2;
            scorecounter += 3;
        }
        if (parachutetaken == false)
        {
            jumpAudio.Play();
        }
        else
        {
            parachuteAudio.Play();
        }
        float randomX;
            if (Random.value < 0.5f)
            {
                randomX = -2;
            }
            else
            {
                randomX = 2;
            }
        float randomY = Random.Range(minY, maxY);
        
        //j += 1;
        if( k > 3)
        {   
            Destroy(PlatformList[0]);
            PlatformList.RemoveAt(0);
            k -= 1;
            j -= 1;
            if (selectedplayer == 0)
            {
                if (parachuteappeared == false)
                {
                    if (Random.value > 0.9f)
                    {
                        pr = (GameObject)Instantiate(parachute, transform.position + new Vector3(PlatformList[j].transform.position.x + randomX, 2.2f + n, 0), transform.rotation);
                        parachuteplatformcounter = j;
                        parachuteappeared = true;
                    }
                }
                else
                {
                    parachuteplatformcounter = parachuteplatformcounter - 1;
                }
            }
            if (selectedplayer == 2)
            {
                Debug.Log("xDDDDDDDDDDDDDDDDDD");
                if (crystalappeared == false)
                {
                    if (Random.value > 0.9f)
                    {
                        cr = (GameObject)Instantiate(crystal, transform.position + new Vector3(PlatformList[j].transform.position.x + randomX, 2.2f + n, 0), transform.rotation);
                        crystalplatformcounter = j;
                        crystalappeared = true;
                    }
                }
                else
                {
                    crystalplatformcounter = crystalplatformcounter - 1;
                }
            }
        }
        PlatformList.Add((GameObject)Instantiate(obstacle, transform.position + new Vector3(PlatformList[j].transform.position.x + randomX, 3 + n, 0), transform.rotation));

        j += 1;
        //Transform IC = GameObject.Instantiate(obstacle, transform.position + new Vector3(randomX, randomY + n, 0), transform.rotation) as Transform;
        //rb.transform.position = PlatformList[l].transform.position + new Vector3(-2.5f, 0.5f, 0);
        //MovePlatforms();

        move = true;
        
        l += 1;

    }
    public void SelectCharacter()
    {
        HideAllCharacters();
        selectedplayer = PlayerPrefs.GetInt(selectedplayername, 0);
        Debug.Log(selectedplayer);
        playerobjects[selectedplayer].SetActive(true);
    }

    public void HideAllCharacters()
    {
        foreach(GameObject g in playerobjects)
        {
            g.SetActive(false);
        }
    }
    void MovePlatforms()
    {

        float x = PlatformList[k].transform.position.x;
        float y = PlatformList[k].transform.position.y;
            for (int i = 0; i < PlatformList.Count; i++)
            {
            //PlatformList[i].transform.Translate(rb.transform.position.x - x, rb.transform.position.y - y - 1.34f, 0);
            float step = speed * Time.deltaTime;
            PlatformList[i].transform.position = Vector3.MoveTowards(PlatformList[i].transform.position, new Vector3(rb.transform.position.x - x, rb.transform.position.y - y - 1.34f, 0), step);


            float m = rb.transform.position.y - y - 1.34f;
              

            }



        k += 1;

    }

    public void TaskOnClick1()
    {
        jump1 = true;
    }

    public void TaskOnClick2()
    {
        reversejump1 = true;
    }

    public void Wait()
    {
        StartCoroutine(_wait());
    }
    IEnumerator _wait()
    {
        yield return new WaitForSeconds(3);
        if (sticheddeathcounter == 0 & selectedplayer == 1)
        {
            //rb.gravityScale = 0;
            sticheddeathcounter = 1;
            pc.revive = true;
            pc.ReviveFun();
            reviveAudio.Play();
        }
        else
        {
            Gmos.Setup(ScoreScript.scoreValue);
        }

    }

    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
