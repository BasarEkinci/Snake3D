using System.Collections.Generic;
using UnityEngine;

namespace Snake3D.Runtime.Controllers
{
    public class PlayerTailController : MonoBehaviour
    {
        [SerializeField] private GameObject tailPrefab;
        [SerializeField] private int gapBetweenParts = 1;
        [SerializeField] private float bodySpeed = 8;
        
        private List<GameObject> _bodyParts = new List<GameObject>();
        private List<Vector3> _positionHistory = new List<Vector3>();
        
        public void Grow()
        {
            GameObject tail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            _bodyParts.Add(tail);
        }
        public void SetTailPosition()
        {
            _positionHistory.Insert(0, transform.position);
            int index = 0;

            foreach (GameObject tail in _bodyParts)
            {
                Vector3 point = _positionHistory[Mathf.Min(index * gapBetweenParts, _positionHistory.Count - 1)];
                Vector3 moveDirection = point - tail.transform.position;
                tail.transform.position += moveDirection * (Time.deltaTime * bodySpeed);
                tail.transform.LookAt(point);
                index++;
            }
        }
    }    
}

