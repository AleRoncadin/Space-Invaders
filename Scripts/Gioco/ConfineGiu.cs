using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfineGiu : MonoBehaviour
{
    public GameObject gameover;
    public GameObject restart;
    public GameObject quit;
    public GameObject menu;
    public GameObject menu_sopra;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Player.isfinish)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
            {
                audioSource.Play();
                Player.isfinish = true;
                gameover.SetActive(true);
                restart.SetActive(true);
                quit.SetActive(true);
                menu.SetActive(true);
                menu_sopra.SetActive(false);
            }
        }
    }
}
