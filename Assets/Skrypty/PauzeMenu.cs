using UnityEngine;
using System.Collections;

public class PauzeMenu : MonoBehaviour {
    public GameObject UI_pauze;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
        {
            UI_pauze.SetActive(true);
            Time.timeScale = 0;
        }


    }
    public void Kont()
    {
        UI_pauze.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        Application.LoadLevelAsync("Main Menu");
        Time.timeScale = 1;
    }

    public void Exit()
    {
        PlayerPrefs.SetInt("Menu", 0);
        Application.Quit();
    }
}
