using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnClickManager : MonoBehaviour
{
    public void PurchaseSuccessful() 
    {
        SoundController.Instance.Play(SoundName.Purchased.ToString());
    }

    public void ClickAnyButtons() 
    {
        SoundController.Instance.Play(SoundName.Click.ToString());
    }

    public void QuitThisApp() 
    {

        Application.Quit();
    }

}
