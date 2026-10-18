using UnityEngine;

public class PeasantSpawner : MonoBehaviour
{
    [SerializeField] private WheatCollect _peasant;
    [SerializeField] private PeasantHealth _peasantHealth;
    private Vector2 _pVector = new Vector2(-16.53f , -0.524976f);
    
    public WheatCollect Spawn()
    {
        _peasantHealth._health = 30f;
        _pVector.x += 1f;
        _pVector.y = -0.524976f;
        WheatCollect worker = Instantiate(_peasant);
        worker.transform.position = _pVector;
        return worker; 
    }
}
