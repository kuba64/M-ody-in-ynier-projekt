using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
    public GameObject UI_load;
    private AsyncOperation async = null;
    //Always start this coroutine in the start function
    private void Start()
    {
        StartCoroutine(LoadLevel(PlayerPrefs.GetInt("Level").ToString()));
    }
    //CoRoutine to return async progress, and trigger level load.
    private IEnumerator LoadLevel(string Level)
    {
        Application.LoadLevelAsync(Level);
        yield return async;
    }

    void Update()
    {
        if(async.progress ==1)
        {
            UI_load.GetComponent<Animator>().SetBool("Play", true);
        }
    }
}
