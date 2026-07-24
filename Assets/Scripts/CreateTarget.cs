using UnityEngine;

public class CreateTarget : MonoBehaviour
{
    public Transform _wall;
    public GameObject _target;
    
    private float _wallX;
    private float _wallY;
    private float _wallZ;
    private float _wallWidth;
    private float _wallHeight;
    void Start()
    {
        _wallX = _wall.position.x;
        _wallY = _wall.position.y;
        _wallZ = _wall.position.z;
        _wallWidth = _wall.localScale.x;
        _wallHeight = _wall.localScale.y;
    }

    void Update()
    {
        if(transform.childCount < 2)
        {
            var newTarget = Instantiate(_target, transform);

            var targetX = UnityEngine.Random.Range(_wallX - _wallWidth / 2, _wallX + _wallWidth / 2);
            var targetY = UnityEngine.Random.Range(_wallY - _wallHeight / 2, _wallY + _wallHeight / 2);
            var targetZ = _wallZ + 4f;

            newTarget.transform.position = new Vector3(targetX, targetY, targetZ);
            
        }
    }
}
