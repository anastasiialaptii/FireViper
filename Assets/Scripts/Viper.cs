using UnityEngine;
using System.Collections.Generic;

public class Viper : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments;

    public Transform segmentPrefub;

    public void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(transform);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A)) {
            _direction = Vector2.left;
        }
    }

    private void FixedUpdate()
    {
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
            print("game over");
            print(other.name);

            //ResetGame();
        }
    }

    private void ResetGame()
    {
        //print("game over");
        //_segments.Clear();
    }
}
