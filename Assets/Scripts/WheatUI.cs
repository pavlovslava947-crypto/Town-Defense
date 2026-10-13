using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WheatUI : MonoBehaviour
{
    [SerializeField] WheatCollect _wheatScript;
    [SerializeField] Image _wheatImage;
    private float _currentTime;
    private float _seconds;
    private float _time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _seconds = _wheatScript._seconds;
        _currentTime = _seconds;

    }

   

    // Update is called once per frame
    void Update()
    {
        _time = _seconds -= Time.deltaTime;
        
        _wheatImage.fillAmount = _seconds / _currentTime;

        if(_seconds <= 0f)
        {
            WhealUpdate();
        }
    }

    void WhealUpdate()
    {
        _wheatImage.fillAmount = 1f;
        _seconds = _currentTime;
    }
}
