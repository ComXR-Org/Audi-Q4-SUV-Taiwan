using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleTransparency : MonoBehaviour
{

    public Color active = Color.white, inactive = new Color(1, 1, 1, 0.3f);
    public float timer = 3f;
    bool timerStopped = false;
    TextMeshProUGUI[] tmpro;
    TextMesh[] txt;

    // Start is called before the first frame update
    void Start()
    {
        // fetch all text components
        tmpro = GetComponentsInChildren<TextMeshProUGUI>(true);
        txt = GetComponentsInChildren<TextMesh>(true);

        // make sure they are inactive at start
        foreach (TextMeshProUGUI tm in tmpro) { tm.color = inactive; }
        foreach (TextMesh t in txt) { t.color = inactive; }

    }

    // Update is called once per frame
    void Update()
    {
        // update the timer
        if (timer > 0f) { timer -= Time.deltaTime; }

        // change color if timer reached 0
        if (timer < 0.1f && !timerStopped)
        {
            timerStopped = true;
            UpdateColor(inactive);
        }
    }

    // make the text opaque
    public void MakeOpaque()
    {
        UpdateColor(active);
        timerStopped = false;
        timer = 3f;
    }

    void UpdateColor(Color col)
    {
        foreach (TextMeshProUGUI tm in tmpro) { tm.color = col; }
        foreach (TextMesh t in txt) { t.color = col; }
        ;
    }
}
