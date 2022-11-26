using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fadein : MonoBehaviour
{

    public Image m_targetImage;
    public float end;
    public float m_fadeDuration = 1f;
    public float m_stayDuration = 2f;
    private float start = 0f;
    public AnimationCurve m_smoothCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(1f, 1f) });
    private float m_timerCurrent;
    private readonly WaitForSeconds m_skipFrame = new WaitForSeconds(0.01f);

    public void StartFade(){
        StartCoroutine(FadeInOut());
    }
    public void EndFade() {
        StartCoroutine(Fade(end, start)); // Fade out.
    }

    private IEnumerator FadeInOut() {
        yield return StartCoroutine(Fade(start, end)); // Fade in.
    }

    private IEnumerator Fade(float start, float end)
    {
        m_timerCurrent = 0f;
        while (m_timerCurrent <= m_fadeDuration)
        {
            m_timerCurrent += Time.deltaTime;
            Color c = m_targetImage.color;
            m_targetImage.color = new Color(c.r, c.g, c.b, Mathf.Lerp(start, end, m_smoothCurve.Evaluate(m_timerCurrent / m_fadeDuration)));
            yield return m_skipFrame;
        }
    }
}