using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public GameObject UI_WyborRobotow, UI_Start, UI_Levels;
    public int iloscPoziomow;
	// Use this for initialization
	void Start () {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Level1", 1);
        

        if (PlayerPrefs.GetInt("Menu", 0) == 1)
        {
            UI_Levels.SetActive(true);
            UI_Start.SetActive(false);
        }
        else
        {
            UI_Levels.SetActive(false);
            UI_Start.SetActive(true);
        }
        SprLevele();
        PlayerPrefs.SetInt("Menu", 0);

    }
	
	// Update is called once per frame
	void Update () {
    
	}

    public void WybierzRobota(int robot)
    {
        PlayerPrefs.SetInt("Robot", robot);
        UI_WyborRobotow.SetActive(false);
        UI_Levels.SetActive(true);
        SprLevele();
    }

    public void Play()
    {
        if (PlayerPrefs.GetInt("Robot",4)==4)
              UI_WyborRobotow.SetActive(true);
        else
            UI_Levels.SetActive(true);

        UI_Start.SetActive(false);
        SprLevele();
    }

    void SprLevele()
    {
        if (UI_Levels.active == true)
        {
            for (int i = 1; i <= iloscPoziomow; i++)
            {
                if (PlayerPrefs.GetInt("Level" + i.ToString()) == 1)
                    GameObject.Find("Canvas/Level/Scroll View/Viewport/Content/" + i.ToString()).GetComponent<Button>().interactable = true;
            }
        }
    }

    public void LoadLevel(int nrLevelu)
    {
        PlayerPrefs.SetInt("Level", nrLevelu);
        Application.LoadLevel("Load");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Level1", 1);
    }
}
