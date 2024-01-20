using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Snake3D.Runtime.Controllers
{
    public class PlayerTailController : MonoBehaviour
    {
        [SerializeField] private int gapBetweenParts = 1;
        [SerializeField] private float bodySpeed = 8;
        
        private readonly List<GameObject> _bodyParts = new List<GameObject>();
        private readonly List<Vector3> _positionHistory = new List<Vector3>();
        
        internal void Grow(GameObject tailPrefab)
        {
            GameObject tail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            _bodyParts.Add(tail);
        }
        
        internal void Shrink()
        {
            if (_bodyParts.Count > 1)
            {
                foreach (var tail in _bodyParts)
                {
                    tail.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
                    {
                        Destroy(tail);
                    });
                }
            }
        }
        internal void SetTailPosition()
        {
            _positionHistory.Insert(0, transform.position);
            int index = 0;

            foreach (GameObject tail in _bodyParts)
            {
                Vector3 point = _positionHistory[Mathf.Min(index * gapBetweenParts , _positionHistory.Count - 1)];
                Vector3 moveDirection = point - tail.transform.position;
                tail.transform.position += moveDirection * (Time.deltaTime * bodySpeed);
                tail.transform.LookAt(point);
                index++;
            }
        }
    }    
}
