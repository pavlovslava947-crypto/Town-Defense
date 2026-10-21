using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RandomEventSystem : MonoBehaviour
{
   
    [SerializeField] private EnemyTimer _timer;
    private UniversalAdditionalCameraData _cameraData;
    private int _chance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _timer = FindAnyObjectByType<EnemyTimer>();

        _cameraData = Camera.main.GetUniversalAdditionalCameraData();
        _cameraData.renderPostProcessing = false;
        
    }
    
    void Update()
    {
        if(_timer._timer <= 0)
        {
            _chance = Random.Range(0, 101);
            Debug.Log(_chance);
        }
        

        if (_chance == 100)
        {
            Plague();
        }

        else
        {
            
        }

    }

    void Plague()
    {
        _cameraData.renderPostProcessing = true;
        _timer._seconds = _timer._seconds - 20f;
    }
}
