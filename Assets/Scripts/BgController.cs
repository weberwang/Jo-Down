using UnityEngine;
using System.Collections;

public class BgController : MonoBehaviour
{

    // Use this for initialization
    private float velocity;
    public float height
    {
        get{return _height;}
    }
    
    private float _height;
    void Start()
    {
        velocity = Camera.main.GetComponent<GameManager>().velocity;
        _height = GetComponent<Renderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - velocity / 20.0f, transform.position.z);
    }
}
