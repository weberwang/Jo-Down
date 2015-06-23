using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{

    // Use this for initialization
    private float velocity;
    void Start()
    {
        velocity = Camera.main.GetComponent<GameManager>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(transform.position.x, transform.position.y + velocity, transform.position.z);
    }
}
