using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private string _gamePlayScene = "SampleScene";
    

   


    public void OnPlayyButtonClick()
    {
        _audioSource.Play();
        SceneManager.LoadScene(_gamePlayScene);



    }
}
