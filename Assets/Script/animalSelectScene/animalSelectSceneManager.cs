using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class animalSelectSceneManager : MonoBehaviour {
    public Canvas firstCanvas;
    public Canvas secondCanvas;
    public GameObject selectPanel;
    public GameObject namePanel;
    public Text selectText;
    public Text nameText;
    public Text hintText;
    public Text nameSelectText;
    int mySelect = 0;
    void selectSetting()
    {
        switch (mySelect)
        {
            case 0:
                selectText.text = "역시 귀여운 강아지를 고르실거죠?";
                break;
            case 1:
                selectText.text = "글쎄... 진짜 고양이 고를거야?";
                break;
        }
    }
    public void Dog()
    {
        mySelect = 0;
        selectPanel.SetActive(true);
        selectSetting();
    }
    public void Cat()
    {
        mySelect = 1;
        selectPanel.SetActive(true);
        selectSetting();
    }
    public void selectYes()
    {
        PlayerPrefs.SetInt("Animal", mySelect);
        firstCanvas.gameObject.SetActive(false);
        secondCanvas.gameObject.SetActive(true);
        switch (mySelect)
        {
            case 0:
                hintText.text = "우리 귀엽고 깜찍한 댕댕이의 이름은?";
                break;
            case 1:
                hintText.text = "성깔 드러운 느그 떼껄룩의 이름은?";
                break;
        }
    }
    public void selectNo()
    {
        selectPanel.SetActive(false);
    }
    public void Name()
    {
        namePanel.SetActive(true);
        nameSelectText.text = nameText.text + "?";
    }
    public void nameYes()
    {
        PlayerPrefs.SetString("Name", nameText.text);
        PlayerPrefs.SetInt("Str", 0);
        PlayerPrefs.SetInt("Dex", 0);
        PlayerPrefs.SetInt("Int", 0);
        PlayerPrefs.SetInt("Luk", 0);
        PlayerPrefs.SetInt("Money", 1000);
        SceneManager.LoadScene("animalScene");
    }
    public void nameNo()
    {
        nameText.text = "";
        namePanel.SetActive(false);
    }
}
