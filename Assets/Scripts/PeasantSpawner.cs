using UnityEngine;

public class PeasantSpawner : MonoBehaviour
{
    [SerializeField] private WheatCollect _peasant;
    private Vector2 _pVector = Vector2.zero;
    
    public WheatCollect Spawn()
    {
        _pVector.x += 1f;
        _pVector.y = - 0.68f;
        WheatCollect worker = Instantiate(_peasant);
        worker.transform.position = _pVector;
        return worker;
    }
}
