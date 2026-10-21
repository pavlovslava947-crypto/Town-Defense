using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void OnButtonClick()
    {
        m_AudioSource.Play();
    }

    
}
