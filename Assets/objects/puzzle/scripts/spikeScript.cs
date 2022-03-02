using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(isActiveScript))]

public class spikeScript : MonoBehaviour
{

    public bool isActive = true;

    public void Start() {



    }

    public void Update() {

        this.isActive = !gameObject.GetComponent<isActiveScript>().isActive;
        gameObject.GetComponent<Animator>().SetBool("isUp", !isActive);
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //checks if the collision is with a player
        if (collision.gameObject.CompareTag("Player") && isActive)
        {

            gameObject.GetComponent<AudioSource>().Play(0);
            Destroy(collision.gameObject);
            StartCoroutine(wait1Sec());

        }

    }

    public IEnumerator wait1Sec() {

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
