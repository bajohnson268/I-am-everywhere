using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalScript : MonoBehaviour
{

    public Sprite openSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //checks if the collision is with a player
        if (collision.gameObject.CompareTag("Player"))
        {

            gameObject.GetComponent<SpriteRenderer>().sprite = openSprite;
            gameObject.GetComponent<AudioSource>().Play(0);

            StartCoroutine(nextLevel());

        }
    }

    public IEnumerator nextLevel() {

        string levelName = SceneManager.GetActiveScene().name;
        int levelNumber = int.Parse(levelName.Substring(levelName.Length - 1));
        levelName = levelName.Substring(0, levelName.Length - 1) + (levelNumber + 1);

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);


    }
}
