using UnityEngine;
using System.Collections;

public class BlokiCzujnika : MonoBehaviour {
    public int nrObiektu, nrCzynnosci;

    Robot Robot;
    // Use this for initialization
    void Start () {
        Robot = GameObject.FindGameObjectWithTag("Player").GetComponent<Robot>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PredkoscZM(float i)
    {
        Robot.newSpeed = i;
    }

    public void DestroyButtonCzy()
    {
        UI.instance.wybCzuj.GetComponent<Kod>().czynnosci[nrCzynnosci] = 0;
        UI.instance.limityCZY[UI.instance.aktulaneUsta]--;
        Destroy(gameObject);
    }

    public void DestroyButtonObt()
    {
        UI.instance.wybCzuj.GetComponent<Kod>().obiekty[nrObiektu] = 0;
        UI.instance.limityOBJ[UI.instance.aktulaneUsta]--;
        Destroy(gameObject);
    }
}
