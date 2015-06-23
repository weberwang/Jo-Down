using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public float velocity;
    public List<GameObject> spkies;

    public GameObject bg0;
    public GameObject bg1;

    private float bgHeight;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < spkies.Count; i++)
        {
            spkies[i].GetComponent<MouseEvent>().enabled = false;
        }
        spkies[0].GetComponent<MouseEvent>().enabled = true;

        bgHeight = bg0.GetComponent<BgController>().height;
    }

    // Update is called once per frame
    void Update()
    {
        if (bg0.transform.position.y > bgHeight)
        {
            bg0.transform.position = new Vector3(bg0.transform.position.x, bg1.transform.position.y - bgHeight, bg0.transform.position.z);
        }

        if (bg1.transform.position.y > bgHeight)
        {
            bg1.transform.position = new Vector3(bg1.transform.position.x, bg0.transform.position.y - bgHeight, bg1.transform.position.z);
        }
    }

    private void Swipe()
    {
        Debug.Log(spkies.Count);
        if (spkies.Count > 0)
        {
            spkies.RemoveAt(0);
            Debug.Log(spkies.Count);
            if (spkies.Count > 0) spkies[0].GetComponent<MouseEvent>().enabled = true;
        }
    }
}
