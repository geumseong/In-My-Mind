using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject creditCanvas;

    // Start is called before the first frame update
    void Start()
    {
        creditCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadCredit() {
        mainCanvas.SetActive(false);
        creditCanvas.SetActive(true);
    }

    public void BackFromCredit() {
        mainCanvas.SetActive(true);
        creditCanvas.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
    }
}
