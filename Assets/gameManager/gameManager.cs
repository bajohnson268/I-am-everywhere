using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public GameObject pauseMenu;

    public GameObject canvas;

    public Text text;

    public void Start() {

        StartCoroutine(wait());
    
    }

    public IEnumerator wait() {

        StartCoroutine(updateText(SceneManager.GetActiveScene().name));
        yield return new WaitForSeconds(4f);
        canvas.SetActive(false);
        //StartCoroutine(updateText(""));

    }

    public IEnumerator updateText(string str) {

        for (int i = 0; i <= str.Length; i++) { 
        
            text.text = str.Substring(0,i);
            yield return new WaitForSeconds(.1f);
        
        }
    
    }

    public void Update() {

        if (Input.GetKeyDown("r")) {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }

        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (pauseMenu.activeSelf)
            {

                pauseMenu.SetActive(false);
                Time.timeScale = 1;

            }

            else {

                pauseMenu.SetActive(true);
                Time.timeScale = 0;

            }
        
        }
    
    }

}
