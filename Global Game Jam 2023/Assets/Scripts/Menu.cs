using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject MenuUI;
    [SerializeField] GameObject HowToPlay;

    // Start is called before the first frame update
    public void Play()
    {
        MenuUI.SetActive(false);
        UI.SetActive(true);
    }

    public void HowToUI()
    {
        HowToPlay.SetActive(true);
    }
    public void CloseHowTo()
    {
        HowToPlay.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/Isaac_dm_Dunn");
    }

    public void Youtube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCvmzyUpsD5RTevsjKtixoHA");
    }

    public void Music()
    {
        Application.OpenURL("https://freemusicarchive.org/music/Pk_jazz_Collective/Things_We_Need_To_Do/02_-_plant_a_tree/");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && UI.active == true)
        {

            MenuUI.SetActive(true);
            UI.SetActive(false);
            HowToPlay.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && UI.active == false)
        {
            MenuUI.SetActive(false);
            UI.SetActive(true);
        }
    }
}
