using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public int LiczbaCzujnikToUse= 7;
    public GameObject UI_bloki,UI_skrypt, UI_czujnikPrefab, UI_listaObiektow, UI_listaCzynnosci, UI_Label;
    public GameObject[] UI_czujniki;
    public Sprite play, stop;
    public Transform transfSkrypt;
    public float odstep = 31f;
    public Image wydajnoscBar;
  
    int iloscCzujnikow;
    public static UI instance;

    public int aktulaneUsta;
    public GameObject wybCzuj;
    public int[] limityOBJ;
    public int[] limityCZY;

    Animator anim;
    // Use this for initialization
    void Start () {
        if (instance == null)
            instance = this;

        UI_czujniki = new GameObject[LiczbaCzujnikToUse];
        limityCZY = new int[LiczbaCzujnikToUse];
        limityOBJ = new int[LiczbaCzujnikToUse];

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        //ustawia obiekt w odstepach 
        for (int i = 0; i < UI_skrypt.transform.childCount; i++)
        {
            Vector3 finish = new Vector3(0, (i + 1) * odstep, 0);
            UI_skrypt.transform.GetChild(i).transform.localPosition = finish;
        }
    }



    public void BlokiOnOff()
    {
        UI_bloki.SetActive(!UI_bloki.activeSelf);
        UI_czujniki[aktulaneUsta].SetActive(false);
      
    }

    public void Add(GameObject blok)
    {
        
        if (blok.name.Contains("Wykryj")&&wydajnoscBar.fillAmount>=(1f/7f))
        {
            iloscCzujnikow++;
            GameObject b = Instantiate(blok, transfSkrypt.position, Quaternion.identity, transfSkrypt) as GameObject;
            b.GetComponent<UI_czujnik>().nr = iloscCzujnikow;
            Ustaw(blok.GetComponent<RectTransform>().position.x);
            wydajnoscBar.fillAmount -= 1f / 7f;
        }
        else if (wydajnoscBar.fillAmount >= (1f / 7f))
        {
            Instantiate(blok, transfSkrypt.position, Quaternion.identity, transfSkrypt);
            Ustaw(blok.GetComponent<RectTransform>().position.x);
            wydajnoscBar.fillAmount -= 1f / 7f;
        }
    }

    public void Play()
    {
        bool start = GameObject.FindGameObjectWithTag("Player").GetComponent<Robot>().played;

        GameObject.FindGameObjectWithTag("Player").GetComponent<Robot>().played = !start;
        anim.SetBool("Played", !start);

        //ustawieni przycisku play
        if (!start)
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = stop;
        else
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = play;

            //restart pozycji gracza
            GM.instance.RestartPlayer();
        }

        // wylaczanie elementów interfejsu
        UI_listaObiektow.SetActive(false);
        UI_listaCzynnosci.SetActive(false);
        UI_bloki.SetActive(false);
        UI_czujniki[aktulaneUsta].SetActive(false);

       

      
    }

 


    public void CzujnikUstawien(int i)
    {
        if (UI_czujniki[i] == null)
        {
            GameObject a = (GameObject)Instantiate(UI_czujnikPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            UI_czujniki[i] = a;

        }
        else
        { 
            if(aktulaneUsta!= i)
               UI_czujniki[aktulaneUsta].SetActive(false);
            UI_czujniki[i].SetActive(!UI_czujniki[i].activeSelf);

        }
        UI_bloki.SetActive(false);
        aktulaneUsta = i;
        wybCzuj = EventSystem.current.currentSelectedGameObject;
        UI_listaObiektow.SetActive(false);
        UI_listaCzynnosci.SetActive(false);
    }


    void Ustaw(float d)
    {
        int children = UI_skrypt.transform.childCount;
      
            Vector3 finish = new Vector3(d, (children) * odstep, 0);
            UI_skrypt.transform.GetChild(children - 1).transform.localPosition = finish;
        
        
    }

    public void ListaObkt() {
        UI_listaCzynnosci.SetActive(false);
       UI_listaObiektow.SetActive(!UI_listaObiektow.activeSelf);
    }

    public void AddObkt(GameObject blok)
    {
        if (limityOBJ[aktulaneUsta] < 3)
        {
            Instantiate(blok, UI_czujniki[aktulaneUsta].transform.GetChild(3).GetChild(0).position, Quaternion.identity,
            UI_czujniki[aktulaneUsta].transform.GetChild(3).GetChild(0));
            wybCzuj.GetComponent<Kod>().obiekty[blok.GetComponent<BlokiCzujnika>().nrObiektu] = 1;
            limityOBJ[aktulaneUsta]++;
        }
    }

    public void ListaCzy()
    {
        UI_listaObiektow.SetActive(false);
        UI_listaCzynnosci.SetActive(!UI_listaObiektow.activeSelf);
    }

    public void AddCzy(GameObject blok)
    {
        if (limityCZY[aktulaneUsta] < 3)
        {
            Instantiate(blok, UI_czujniki[aktulaneUsta].transform.GetChild(4).GetChild(0).position, Quaternion.identity,
            UI_czujniki[aktulaneUsta].transform.GetChild(4).GetChild(0));
            wybCzuj.GetComponent<Kod>().czynnosci[blok.GetComponent<BlokiCzujnika>().nrCzynnosci] = 1;
            limityCZY[aktulaneUsta]++;
        }
    }
}
