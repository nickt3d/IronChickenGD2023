using UnityEngine;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    public List<GameObject> menuButtons;

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
