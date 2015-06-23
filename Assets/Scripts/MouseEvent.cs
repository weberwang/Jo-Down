using UnityEngine;
using System.Collections;

public class MouseEvent : MonoBehaviour
{
    private GameManager manager;
    private float widthSize;
    
    // Use this for initialization
    void Start()
    {
       widthSize = gameObject.GetComponent<Collider2D>().bounds.size.x;
    }
    void OnEnable()
    {
        FingerGestures.OnSwipe += OnSwipe;
    }

	void onDisEnable()
	{
		FingerGestures.OnSwipe -= OnSwipe;
	}
    private void OnSwipe(Vector2 startPos, FingerGestures.SwipeDirection direction, float velocity)
    {
        if(!enabled) return;
        swipeSelf(direction);
    }
    
    private void swipeSelf(FingerGestures.SwipeDirection direction)
    {
        bool moved = false;
        switch (direction)
        {
            case MouseGestures.SwipeDirection.Left:
                transform.position = new Vector3(transform.position.x - widthSize/2, transform.position.y, transform.position.z);
                moved = true;
                break;
            case MouseGestures.SwipeDirection.Right:
                transform.position = new Vector3(transform.position.x + widthSize/2, transform.position.y, transform.position.z);
                moved = true;
                break;
        }
        if(moved)
        {
            onDisEnable();
            if(!manager)
            {
                manager = Camera.main.GetComponent<GameManager>();
            }
            manager.SendMessage("Swipe");
            enabled = false;
        }
    }
    // Update is called once per frame
    void OnColliderEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("游戏结束");
        }
    }
}
