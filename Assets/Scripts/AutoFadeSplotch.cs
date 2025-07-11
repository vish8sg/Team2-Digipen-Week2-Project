using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFadeSplotch : MonoBehaviour
{
    private SpriteRenderer sr;
    private float duration = 8f;

    private void OnEnable()
    {
        //Starts fade out animation once object gets enabled
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float t = 0;
        Color originalColor = sr.color;

        //fades out splotch
        while (t < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / duration);
            sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            t += Time.unscaledDeltaTime;
            yield return null;
        }

        //resets splotch properties and returns it to the splotch pool
        sr.color = originalColor;
        SplotchPool.Instance.ReturnSplotch(gameObject);
    }
}
