using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class animalSceneManager : MonoBehaviour {
    public Text nameText;
    public Text moneyText;
    public Text StrFillText;
    public Text DexFillText;
    public Text IntFillText;
    public Text LukFillText;
    public Image Cat;
    public Image Dog;
    public Image StrFill;
    public Image DexFill;
    public Image IntFill;
    public Image LukFill;
    int mySelect;
    int str;
    int dex;    
    int _int;
    int luk;
    int money;
	// Use this for initialization
	void Start () {
        str = PlayerPrefs.GetInt("Str");
        dex = PlayerPrefs.GetInt("Dex");
        _int = PlayerPrefs.GetInt("Int");
        luk = PlayerPrefs.GetInt("Luk");
        money = PlayerPrefs.GetInt("Money");
        mySelect = PlayerPrefs.GetInt("Animal");
        nameText.text = PlayerPrefs.GetString("Name") + "네 집";
        switch (mySelect)
        {
            case 0:
                Dog.gameObject.SetActive(true);
                break;
            case 1:
                Cat.gameObject.SetActive(true);
                break;
        }      
	}
	
	// Update is called once per frame
	void Update () {
        StrFill.fillAmount = str / 100f;
        DexFill.fillAmount = dex / 100f;
        IntFill.fillAmount = _int / 100f;
        LukFill.fillAmount = luk / 100f;
        StrFillText.text = str + "";
        DexFillText.text = dex + "";
        IntFillText.text = _int + "";
        LukFillText.text = luk + "";
        moneyText.text = money + " G";
        if(str >= 100 && dex >= 100 && _int >= 100 && luk >= 100)
        {
            PlayerPrefs.SetInt("Str", str);
            PlayerPrefs.SetInt("Dex", dex);
            PlayerPrefs.SetInt("Int", _int);
            PlayerPrefs.SetInt("Luk", luk);
            PlayerPrefs.SetInt("Money", money);
            SceneManager.LoadScene("clearScene");
        }
    }
    public void mainScene()
    {
        PlayerPrefs.SetInt("Str", str);
        PlayerPrefs.SetInt("Dex", dex);
        PlayerPrefs.SetInt("Int", _int);
        PlayerPrefs.SetInt("Luk", luk);
        PlayerPrefs.SetInt("Money", money);
        SceneManager.LoadScene("mainScene");
    }
    public void resetData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("mainScene");
    }
    public void cheat()
    {
        money += 1000;
    }
    public void strUp()
    {
        if(money >= 500)
        {
            str += (int)Random.Range(1, 11);
            money -= 500;
        }
    }
    public void dexUp()
    {
        if (money >= 500)
        {
            dex += (int)Random.Range(1, 11);
            money -= 500;
        }
    }
    public void intUp()
    {
        if (money >= 500)
        {
            _int += (int)Random.Range(1, 11);
            money -= 500;
        }
    }
    public void lukUp()
    {
        if (money >= 500)
        {
            luk += (int)Random.Range(1, 11);
            money -= 500;
        }
    }
}
