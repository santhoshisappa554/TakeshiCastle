using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInTransition : MonoBehaviour
{
    public float fadeInTime;
    Image fadePanel;
    Color currentColor = Color.black;

    // Start is called before the first frame update
    void Start()
    {
        fadePanel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
