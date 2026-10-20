using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
   
    private string _gamePlayScene = "SampleScene";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    // Update is called once per frame
    

    public void OnPlayyButtonClick()
    {
        SceneManager.LoadScene(_gamePlayScene);

    }
}
