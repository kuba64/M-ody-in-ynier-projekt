using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {
    public Transform spawnPlayer;
    public GameObject[] player;
    public int[] levelToUnlock;

    public static GM instance;
	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;

        Instantiate(player[PlayerPrefs.GetInt("Robot")], spawnPlayer.position, Quaternion.identity);
        PlayerPrefs.SetInt("Menu", 0);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPlayer.position;
    }

    public void Finish()
    {
        for(int i =0; i<levelToUnlock.Length;i++)
        {
            PlayerPrefs.SetInt("Level" + levelToUnlock[i].ToString(), 1);
        }
        PlayerPrefs.SetInt("Menu", 1);
        Application.LoadLevel("Main Menu");
    }
}
