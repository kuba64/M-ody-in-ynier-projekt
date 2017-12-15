using UnityEngine;
using System.Collections;

public class UI_czujnik : MonoBehaviour
{
    public int nr;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Ustawienia()
    {
        UI.instance.CzujnikUstawien(nr - 1);
    }
    public void ListaO()
    {
        UI.instance.ListaObkt();
    }

    public void ListaC()
    {
        UI.instance.ListaCzy();
    }
    public void Exit()
    {
        gameObject.SetActive(false);
        UI.instance.UI_listaCzynnosci.SetActive(false);
        UI.instance.UI_listaObiektow.SetActive(false);
    }
}
