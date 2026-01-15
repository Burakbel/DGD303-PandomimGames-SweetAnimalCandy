using UnityEngine;
using TMPro;
using System.Collections;

public class UIWarningManager : MonoBehaviour
{
    public static UIWarningManager Instance;

    public TextMeshProUGUI warningText;

    Coroutine routine;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        SetAlpha(0f);
    }

    public void Show(string message)
    {
        warningText.text = message;

        if (routine != null)
            StopCoroutine(routine);

        routine = StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        float fadeTime = 0.8f;
        float stayTime = 1.2f;

        yield return Fade(0f, 1f, fadeTime);
        yield return new WaitForSeconds(stayTime);
        yield return Fade(1f, 0f, fadeTime);
    }

    IEnumerator Fade(float from, float to, float time)
    {
        float t = 0f;

        while (t < time)
        {
            t += Time.deltaTime;
            SetAlpha(Mathf.Lerp(from, to, t / time));
            yield return null;
        }

        SetAlpha(to);
    }

    void SetAlpha(float a)
    {
        Color c = warningText.color;
        c.a = a;
        warningText.color = c;
    }
}
