using UnityEngine;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    public List<GameObject> menuScreens;

    public List<GameObject> menuButtons;

    private void Start()
    {
        menuScreens[0].SetActive(true);

        for (int i = 1; i < menuScreens.Count; ++i)
        {
            menuScreens[i].SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetButtonScale()
    {
        foreach (GameObject btn in menuButtons)
        {
            btn.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
