using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class clearSceneManager : MonoBehaviour {
    public Text clearMessage;
    public InputField input;
    public Image Dog;
    public Image Cat;
    public Image Human;
    public Image Devil;
    public Image []myHearts = new Image[5];
    public Image[] yourHearts = new Image[5];
    public Text DevilText;
    public Canvas can1;
    public Canvas can2;
    public Canvas can3;
    int index = 0;
    int oldIndex;
    int animal;
    int myHp = 5;
    int yourHp = 5;
    string name;
    // Use this for initialization
    void Start () {
        animal = PlayerPrefs.GetInt("Animal");
        name = PlayerPrefs.GetString("Name");
        if (animal == 0)
            Dog.gameObject.SetActive(true);
        else
            Cat.gameObject.SetActive(true);
        oldIndex = index;
        StartCoroutine("co" + index);
	}
	
	// Update is called once per frame
	void Update () {
        if (oldIndex != index)
        {
            if(index == 4)
            {
                index4();
                index++;
            }
            else if(index <= 3)
            {
                oldIndex = index;
                StartCoroutine("co" + index);
            }
        }
        if (Input.GetKey(KeyCode.Return))
        {
            input.Select();
            input.ActivateInputField();
        }
	}
    IEnumerator co0()
    {
        clearMessage.text = "어랏 " + name + "의 모습이?!";
        yield return new WaitForSeconds(1.5f);
        clearMessage.text = "";
        index++;
    }
    IEnumerator co1()
    {
        float time = 0.3f;
        do
        {
            myAnimalToggleActive(animal);
            yield return new WaitForSeconds(time);
            time -= 0.01f;
        } while (time >= 0);
        index++;
    }
    IEnumerator co2()
    {
        Human.gameObject.SetActive(true);
        clearMessage.text = "축하합니다 " + name + "은 미완벽 사람이 됬습니다";
        yield return new WaitForSeconds(1.5f);
        index++;
    }
    string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    IEnumerator co3()
    {
        string[] spellList = { "갓동아리제로픈", "로운아사랑해", "내이름은코난탐정이죠", "soft한ware과", "나는악마다", "꺄악변태다", "삐뤼뚜땁", "콰직", "악", "마" };

        int spellIndex = 0;
        Human.transform.localScale = new Vector2(0.5f, 0.5f);
        Human.transform.localPosition = new Vector2(480, -150);
        yield return new WaitForSeconds(2f);
        clearMessage.text = name + "이 악마랑 싸워 이겨야 완벽 사람이 됩니다";
        yield return new WaitForSeconds(2f);
        clearMessage.text = "악마의 주문을 반대로 입력하면\n악마가 데미지를 입습니다";
        yield return new WaitForSeconds(2f);
        clearMessage.text = "5초안에 입력 못 할 경우 " + name + "이 데미지를 입습니다";
        yield return new WaitForSeconds(2f);
        clearMessage.text = "그러면 건투를 빌겠습니다";
        yield return new WaitForSeconds(2f);
        clearMessage.text = "";
        for(int i=0; i<5; i++)
        {
            myHearts[i].gameObject.SetActive(true);
            yourHearts[i].gameObject.SetActive(true);
        }
        input.gameObject.SetActive(true);
        Devil.gameObject.SetActive(true);
        DevilText.gameObject.SetActive(true);
        
        do
        {
            DevilText.text = spellList[spellIndex];
            yield return new WaitForSeconds(5.0f);
            if (Reverse(spellList[spellIndex]).Equals(input.text))
            {
                yourHearts[--yourHp].gameObject.SetActive(false);
            }
            else
            {
                myHearts[--myHp].gameObject.SetActive(false);
            }
            input.text = "";
            input.Select();
            input.ActivateInputField();
            spellIndex++;
        } while (myHp >0 && yourHp > 0);
        index++;
    }
    void index4()
    {
        can1.gameObject.SetActive(false);
        if (myHp != 0)
            can2.gameObject.SetActive(true);
        else
            can3.gameObject.SetActive(true);
    }
    void myAnimalToggleActive(int _animal)
    {
        if (_animal == 0)
            Dog.gameObject.SetActive(!Dog.gameObject.activeSelf);
        else
            Cat.gameObject.SetActive(!Cat.gameObject.activeSelf);
    }
    public void mainMenu()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("mainScene");
    }
}
