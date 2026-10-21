using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Pause();
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
    }

    public void OnContueButton()
    {
        Time.timeScale = 1.0f;
        _pausePanel.SetActive(false);
    }
}
