using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBG : MonoBehaviour
{
    public Image BackgroundImage;
    public int _Delay;

    private bool _FadeOut = false;
    private bool _Running = false;

    private void Start()
    {
        GameObject imageObject = GameObject.FindGameObjectWithTag("imgBackground");
        BackgroundImage = imageObject.GetComponent<Image>();
    }

    void Update()
    {
        if (!_Running)
        {
            if (_FadeOut)
            {
                StartCoroutine(FadeOut());
            }
            else
            {
                StartCoroutine(FadeIn());
            }
        }
    }

    IEnumerator FadeOut()
    {
        _Running = true;
        if (BackgroundImage == null)
        {
            GameObject imageObject = GameObject.FindGameObjectWithTag("imgBackground");
            BackgroundImage = imageObject.GetComponent<Image>();
        }

        Color tmpColor = BackgroundImage.color;

        while (BackgroundImage.color.a > 0.0f)
        {
            tmpColor.a -= Time.deltaTime / 4;
            BackgroundImage.color = tmpColor;
            yield return null;
        }

        _FadeOut = false;
        _Running = false;
        yield return null;
    }

    IEnumerator FadeIn()
    {
        _Running = true;
        if (BackgroundImage == null)
        {
            GameObject imageObject = GameObject.FindGameObjectWithTag("imgBackground");
            BackgroundImage = imageObject.GetComponent<Image>();
        }

        Color tmpColor = BackgroundImage.color;

        while (BackgroundImage.color.a < 1.0f)
        {
            tmpColor.a += Time.deltaTime / 4;
            BackgroundImage.color = tmpColor;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(_Delay);

        _FadeOut = true;
        _Running = false;
        yield return null;
    }
}
