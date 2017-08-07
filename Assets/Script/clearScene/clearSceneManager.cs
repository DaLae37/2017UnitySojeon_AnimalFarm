using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class clearSceneManager : MonoBehaviour {
    public Text clearMessage;
    public Image Dog;
    public Image Cat;
    public Image Human;
    int index = 0;
    int oldIndex;
    int animal;
    int myHp = 5;
    int yourHp = 5;
    // Use this for initialization
    void Start () {
        animal = PlayerPrefs.GetInt("Animal");
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
            oldIndex = index;
            StartCoroutine("co" + index);
        }
	}
    IEnumerator co0()
    {
        clearMessage.text = "어랏 " + PlayerPrefs.GetString("Name") + "의 모습이?!";
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
        clearMessage.text = "축하합니다 " + PlayerPrefs.GetString("Name") + "은 사람이 됬습니다";
        yield return new WaitForSeconds(1.5f);
        index++;
    }
    IEnumerator co3()
    {
        do
        {
            yield return new WaitForSeconds(3.0f);
        } while (myHp > 0 || yourHp > 0);
    }
    void myAnimalToggleActive(int _animal)
    {
        if (_animal == 0)
            Dog.gameObject.SetActive(!Dog.gameObject.activeSelf);
        else
            Cat.gameObject.SetActive(!Cat.gameObject.activeSelf);
    }
}
