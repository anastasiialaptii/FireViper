using UnityEngine;
using System.Collections.Generic;

public class Viper : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    [SerializeField]
    private Stats _stats;
    [SerializeField]
    private GameManager _gm;

    public Transform segmentPrefub;

    public void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(transform);
    }

    public void Update()
    {
        if (!_stats.isPlayerAlive()) return;

        if (Input.GetKeyDown(KeyCode.W)) {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            _direction = Vector2.right;
            
            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else if (Input.GetKeyDown(KeyCode.A)) {
            _direction = Vector2.left;

            var scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    private void FixedUpdate()
    {
        if (!_stats.isPlayerAlive()) return;

        for (var i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;

        }

        transform.position = new Vector3(
                    Mathf.Round(transform.position.x) + _direction.x,
                    Mathf.Round(transform.position.y) + _direction.y,
                    0.0f
                );
    }

    private void Grow()
    {
        var segment = Instantiate(segmentPrefub);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        
        if (other.tag == "Obstacle") {
            _stats.ChangeLife(1);

            if(!_stats.isPlayerAlive())
            {
                _gm.GameOver();
            }
        }
    }
}
