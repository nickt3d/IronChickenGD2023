using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void Select()
    {
        AudioManager.Instance.Play("ButtonClick");
    }

    public void BloodSplat()
    {
        AudioManager.Instance.Play("BloodSplat");
    }

    public void PlayButton()
    {
        AudioManager.Instance.Stop("Theme");
        AudioManager.Instance.Play("GameMusic");
    }
}
