using UnityEngine;
using System.Collections;

public class Kod : MonoBehaviour {
    Robot Robot;

    public enum ClassType { Move, Jump, CzujnikObiektu, Predkosc}
    [SerializeField]
    public ClassType Dzialanie;
    public int[] obiekty;
    public int[] czynnosci;
    // Use this for initialization
    void Start () {
        Robot = GameObject.FindGameObjectWithTag("Player").GetComponent<Robot>();
        obiekty = new int[10];
        czynnosci = new int[10];
    }

    // Update is called once per frame
    void Update()
    {
        if (Robot.played)
        {
            switch (Dzialanie)
            {
                case ClassType.Move:
                    Robot.Move();
                    break;

                case ClassType.Jump:
                    Debug.Log("Jump");
                    Robot.Jump(100);
                    break;

                case ClassType.CzujnikObiektu:
                    Robot.CzujnikObiektu(obiekty,czynnosci);
                    break;

            }
        }
    }

    public void PredkoscZM(float i)
    {
        Robot.speed = i;
    }
    public void Usun()
    {
        UI.instance.wydajnoscBar.fillAmount += 1f / 7f;
        Destroy(gameObject);
    }


}
