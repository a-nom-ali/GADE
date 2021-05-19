using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas m_Canvas;
    [SerializeField] private AnimationCurve m_PulseCurve;
    [SerializeField] private float m_PulseTime =.5f;
    
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private float _startTime = 0;
    

    public void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        m_Canvas = m_Canvas ?? FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        if (!_canvasGroup.blocksRaycasts)
        {
            if (Time.time - _startTime <= m_PulseTime)
            {
                var normalizedTime = (Time.time - _startTime) / m_PulseTime;
                _rectTransform.localScale = Vector3.one * ( 1 + m_PulseCurve.Evaluate(normalizedTime));
            }
            else
            {
                _startTime = Time.time;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = .5f;
        
        _startTime = Time.time;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;

        //_rectTransform.localScale = Vector3.one;
        StartCoroutine(LerpScale(Vector3.one));
    }

    private IEnumerator LerpScale(Vector3 scale)
    {
        var startScale = _rectTransform.localScale;
        while (_canvasGroup.blocksRaycasts && Time.time - _startTime < m_PulseTime)
        {
            _rectTransform.localScale = Vector3.Lerp(startScale, scale, (Time.time - _startTime) / m_PulseTime);
            yield return new WaitForEndOfFrame();
        }

        _rectTransform.localScale = scale;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / m_Canvas.scaleFactor;
    }

}
