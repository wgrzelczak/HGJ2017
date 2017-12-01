using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    //public GameObject credits;
    public GameObject noCredits;

    bool isCreditsOnCanv = false;

    private void Start()
    {
        //credits.SetActive(isCreditsOnCanv);
        //noCredits.SetActive(!isCreditsOnCanv);
    }

    private void Update()
    {
        if(Input.GetButtonDown("A_Pad1") || Input.GetButtonDown("A_Pad2"))
        {
            StartGame();
        }
        if (Input.GetButtonDown("B_Pad1") || Input.GetButtonDown("B_Pad2"))
        {
            ChangeMenu();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Loop");
    }

    public void ChangeMenu()
    {
        isCreditsOnCanv = !isCreditsOnCanv;
        //credits.SetActive(isCreditsOnCanv);
        //noCredits.SetActive(!isCreditsOnCanv);
    }
}
