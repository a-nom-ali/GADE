using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GADE2.UI
{
    public class MoverUI : MonoBehaviour
    {
        public Mover[] Movers;
        public UnityEvent TopReached;
        public UnityEvent BottomReached;
        private float _currentMinHeight;
        private float _currentMaxHeight;
        private Text _text;
        private float _maxHeight;
        private float _minHeight;

        // Start is called before the first frame update
        void Start()
        {
            if (TopReached == default(UnityEvent))
                TopReached = new UnityEvent();
            
            if (BottomReached == default(UnityEvent))
                BottomReached = new UnityEvent();
            
            _text = GetComponent<Text>();

            if (Movers.Length == 0)
            {
                Movers = FindObjectsOfType<Mover>().ToArray();
            }

            _maxHeight = Movers.Max(m => m.MaxHeight);
            _minHeight = Movers.Min(m => m.MinHeight);
        }

        void Update()
        {
            var maxHeight = Mathf.NegativeInfinity;
            var minHeight = Mathf.Infinity;

            for (var i = 0; i < Movers.Length; i++)
            {
                maxHeight = Mathf.Max(maxHeight, Movers[i].transform.position.y);
                minHeight = Mathf.Min(minHeight, Movers[i].transform.position.y);
            }

            //var i=0;
            //while (i < Movers.Length)
            // {
            //     maxHeight = Mathf.Max(maxHeight, Movers[i].transform.position.y);
            //     minHeight = Mathf.Min(minHeight, Movers[i].transform.position.y);
            //     i++
            // }

            // foreach (var target in Movers)
            // {
            //     maxHeight = Mathf.Max(maxHeight, target.transform.position.y);
            //     minHeight = Mathf.Min(minHeight, target.transform.position.y);
            // }

            _currentMinHeight = minHeight;
            _currentMaxHeight = maxHeight;

            if (_currentMaxHeight >= _maxHeight)
            {
                Debug.Log("Top reached");
                TopReached.Invoke();
            }
            
            if (_currentMinHeight <= _minHeight)
                BottomReached.Invoke();
            
            _text.text = string.Format("Min: {0:0.00}\nMax: {1:0.00}", _currentMinHeight, _currentMaxHeight);
        }

        private void OnDrawGizmos()
        {
            var radius = 3f;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(
                new Vector3(1, _currentMinHeight, 0),
                new Vector3(1, _currentMaxHeight, 0)
                );
            // Gizmos.color = Color.blue;
            // Gizmos.DrawWireSphere(
            //     new Vector3(1, _currentMinHeight, 0),
            //     radius
            //     );
        }
    }
}