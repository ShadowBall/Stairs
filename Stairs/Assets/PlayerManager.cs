using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image im;
    public SpawnPlatform spl;
    public List<GameObject> players = new List<GameObject>();
    public int selectedplayer = 0;
    private string selectedplayername = "SelectedPlayer";
    public GameObject PreviousButton;
    public GameObject NextButton;
    public GameObject SwatDetails;
    public GameObject StitchedDetails;
    public GameObject ExplorerDetails;
    //public GameObject character;

    
    void Start()
    {
        //spl = GameObject.Find("SpawnPoint").GetComponent<SpawnPlatform>();
    }
    public void NextOption()
    {   
        players[selectedplayer].SetActive(false);
        //spl.playerobjects[selectedplayer].SetActive(false);
        selectedplayer = selectedplayer + 1;
        if(selectedplayer == 0)
        {
            SwatDetails.SetActive(true);
        }
        else
        {
            SwatDetails.SetActive(false);
        }
        if (selectedplayer == 1)
        {
            StitchedDetails.SetActive(true);
        }
        else
        {
            StitchedDetails.SetActive(false);
        }
        if (selectedplayer == 2)
        {
            ExplorerDetails.SetActive(true);
            PreviousButton.SetActive(true);
        }
        else
        {
            ExplorerDetails.SetActive(false);
        }
        players[selectedplayer].SetActive(true);
        //spl.playerobjects[selectedplayer].SetActive(true);
        if (selectedplayer == players.Count-1)
        {
            NextButton.SetActive(false);
        }

        //im = players[selecterplayer];
    }

    public void PreviousOption()
    {
        NextButton.SetActive(true);
        players[selectedplayer].SetActive(false);
        //spl.playerobjects[selectedplayer].SetActive(false);
        selectedplayer = selectedplayer - 1;
        players[selectedplayer].SetActive(true);
        //spl.playerobjects[selectedplayer].SetActive(true);
        if (selectedplayer == 0)
        {
            PreviousButton.SetActive(false);
        }
        if (selectedplayer == 0)
        {
            SwatDetails.SetActive(true);
        }
        else
        {
            SwatDetails.SetActive(false);
        }
        if (selectedplayer == 1)
        {
            StitchedDetails.SetActive(true);
        }
        else
        {
            StitchedDetails.SetActive(false);
        }
        if (selectedplayer == 2)
        {
            ExplorerDetails.SetActive(true);
            PreviousButton.SetActive(true);
        }
        else
        {
            ExplorerDetails.SetActive(false);
        }

        //im = players[selecterplayer];
    }

       public void SelectCharacter()
    {
        PlayerPrefs.SetInt(selectedplayername, selectedplayer);
        Debug.Log(selectedplayer);
    }
}
