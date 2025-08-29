using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private Stats _stats;
    private int _foodPoint = 1;

    public BoxCollider2D foodGrid;
   

    public void Start()
    {
        RandomizeFoodSpawn();
    }

    private void RandomizeFoodSpawn()
    {
        var bounds = this.foodGrid.bounds;

        var x = Random.Range(bounds.min.x, bounds.max.x);
        var y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _stats.ChangeScore(_foodPoint);

            RandomizeFoodSpawn();
        }
    }
}
