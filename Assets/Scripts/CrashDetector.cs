using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float restartDelay = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControlls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("RestartScene", restartDelay);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
