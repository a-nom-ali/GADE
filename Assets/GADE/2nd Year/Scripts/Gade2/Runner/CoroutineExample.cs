using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CoroutineExample : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Color m_Color1 = Color.blue;
    [SerializeField] private Color m_Color2 = Color.green;
    [SerializeField] private float m_Period = 1f;
    private Coroutine _coroutine;
    private Image _image;
    private Color _startColor;
    private Coroutine _speedBoostCoroutine;

    public void Start()
    {
        _image = GetComponent<Image>();
        _startColor = _image.color;
        _coroutine = StartCoroutine(PulseColors());
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_coroutine != null)
            _coroutine = StartCoroutine(PulseColors());
    }

    private IEnumerator PulseColor(Color start, Color end)
    {
        var startTime = Time.time;
        while (Time.time - startTime < m_Period)
        {
            _image.color = Color.Lerp(start, end, (Time.time - startTime) / m_Period);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator SpeedBoost()
    {
        if (_speedBoostCoroutine != null)
        {
            StopCoroutine(_speedBoostCoroutine);
        }
        
        // set new player speed
        //WFS
        // reset to normal speeed

        yield return new WaitForSeconds(4f);
    }

    private IEnumerator SomeSequence()
    {
        //do first thing
        yield return new WaitForSeconds(4f);
    }

    private IEnumerator PulseColors()
    {
        yield return StartCoroutine(PulseColor(_startColor, m_Color1));
        yield return StartCoroutine(PulseColor(m_Color1, m_Color2));
        yield return StartCoroutine(PulseColor(m_Color2, _startColor));

        _coroutine = null;
    }
}
