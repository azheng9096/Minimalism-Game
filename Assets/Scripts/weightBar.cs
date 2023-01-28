using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weightBar : MonoBehaviour
{
    public int weight = 0;
    public List<GameObject> boxes;
    // Start is called before the first frame update
    void Start()
    {
        UpdateBar();
    }

    // Update is called once per frame

    void UpdateBar()
    {
        if (weight == 0)
        {
            foreach(GameObject i in boxes) {
                i.GetComponent<Renderer>().enabled = false;
            }
        } else
        {
            for(int i = 0; i < 5; i++) {
                if (i >= weight)
                {
                    boxes[i].GetComponent<Renderer>().enabled = false;
                }
                else 
                {
                    boxes[i].GetComponent<Renderer>().enabled = true;
                }
            }
            }
        }

    
    void incWeight()
    {
        weight++;
        UpdateBar();
    }
    void deWeight()
    {
        weight--;
        UpdateBar();
    }
}
