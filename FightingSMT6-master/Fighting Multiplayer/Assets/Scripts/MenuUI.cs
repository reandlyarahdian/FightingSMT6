using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    
    public Button MenuUIButton, SettingUIButton, VersusUIButton, ExitUIButton,
        StoryUIButton, ExtrasUIButton, DeviceUIButton, OnlineUIButton, OptionButton, CharacterSelectB, backB,ControlB;
    public GameObject Menu, Setting, Versus, Exit, Story, Extras, Device, Online, Option, CharacterSelect, Control;
    private BTNSFX bTNSFX;

    public Button player1, player2;

    public GameObject char1, char2;

    public void OpenChar1()
    {
        char1.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(player1.gameObject);
    }
    public void OpenChar2()
    {
        char2.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(player2.gameObject);
    }

    public void OpenOnline()
    {
        Online.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(OnlineUIButton.gameObject);
    }

    public void OpenDevice()
    {
        Device.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(DeviceUIButton.gameObject);
    }

    public void OpenExtras()
    {
        Extras.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(ExtrasUIButton.gameObject);
    }

    public void OpenStory()
    {
        Story.SetActive(true);
        CharacterSelect.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(StoryUIButton.gameObject);
    }

    public void OpenMenu()
    {
        Menu.SetActive(true);
        Option.SetActive(false);
        Device.SetActive(false);
        Online.SetActive(false);


        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(MenuUIButton.gameObject);
    }

    public void OpenSetting()
    {
        Setting.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(SettingUIButton.gameObject);
    }

    public void OpenOption()
    {
        Option.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(OptionButton.gameObject);
    }

    public void CharacterSELECTT()
    {
        CharacterSelect.SetActive(true);

        Story.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(CharacterSelectB.gameObject);

    }

    public void OpenVersus()
    {
        Versus.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(VersusUIButton.gameObject);
    }
    public void OpenExit()
    {
        Exit.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(ExitUIButton.gameObject);
    }

    public void OpeNMainMenu()
    {
        SceneManager.LoadScene("Menu");
        bTNSFX = GetComponent<BTNSFX>();
        bTNSFX.clickSound();
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(ExitUIButton.gameObject);
    }

    public void OpenControl()
    {
        Control.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(ControlB.gameObject);
    }

    

}
