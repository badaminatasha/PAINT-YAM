using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BattleTimer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float totalTime; // in seconds
    [SerializeField] UnityEvent onWin;

    float timeLeft;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = totalTime;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = Mathf.Max(0f, totalTime - (Time.time - startTime));
        if (Mathf.Approximately(timeLeft, 0f) && FindObjectOfType<PlayerHealthCallbacks>().GetComponent<Health>().CurrentHealth != 0f)
            onWin?.Invoke();

        int numMinutes = Mathf.FloorToInt(timeLeft / 60f);
        int numSeconds = Mathf.FloorToInt(timeLeft - numMinutes);
        timerText.text = string.Format("{0}:{1}", numMinutes, numSeconds);
    }
}
