using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public float speed;
    public float time;
    public int hp;
    public GameObject screen;
    public GameObject face;
    public GameObject gameOverMenu;
    public GameObject PauseMenu;
    public List<Sprite> screenImg;
    public List<Sprite> faceImg;

    public List<GameObject> spawnPoints;
    public List<GameObject> icons;
    public GameObject timer;
    public GameObject gameOverTimerDisplay;
    int playTime;


    // Start is called before the first frame update
    void Start()
    {
        speed = 2.5f;
        hp = 2;
        time = 2f;
        StartCoroutine(IncreaseSpeed());
        StartCoroutine(StartSpawn());
        StartCoroutine(CountTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSpawn() {
        while(true) {
            int spawnIndex = Random.Range(0, 7);
            GameObject nIcon = Instantiate(icons[Random.Range(0, 8)], spawnPoints[spawnIndex].transform);
            yield return new WaitForSeconds(time);
        }
    }

    IEnumerator IncreaseSpeed() {
        while(true) {
            yield return new WaitForSeconds(3f);
            speed += 0.1f;
            time -= 0.1f;
        }
    }
    IEnumerator CountTime() {
        while(true) {
            yield return new WaitForSeconds(1f);
            timer.GetComponent<Text>().text = playTime + "s";
            playTime += 1;
        }
    }

    public void HealthDown() {
        hp--;
        ChangeSprite();
        if(hp == 0) {
            gameOverTimerDisplay.GetComponent<Text>().text = "Time Wasted:\n" + playTime + "s";
            GameObject.Find("MenuManager").GetComponent<MenuManager>().GameOver();
        }
    }

    public void ChangeSprite() {
        screen.GetComponent<SpriteRenderer>().sprite = screenImg[hp];
        face.GetComponent<SpriteRenderer>().sprite = faceImg[hp];
    }
}
