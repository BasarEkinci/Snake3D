using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Snake3D.Runtime.Controllers.Player
{
    public class PlayerTailController : MonoBehaviour
    {
        [SerializeField] private int gapBetweenParts = 1;
        [SerializeField] private float bodySpeed = 8;
        
        [SerializeField] private List<GameObject> _bodyParts;
        
        private readonly List<Vector3> _positionHistory = new List<Vector3>();
        private Vector3 _tailSpawnPosition;

        private GameObject _tail;
        internal void Grow(GameObject tailPrefab)
        {
            _tail = Instantiate(tailPrefab, _bodyParts[_bodyParts.Count - 1].transform.position, Quaternion.identity);
            _bodyParts.Add(_tail);
        }
        
        internal void Shrink()
        {
            foreach (GameObject tile in _bodyParts.Skip(1))
            {
                tile.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
                {
                    Destroy(tile);
                });
            }
            _bodyParts.RemoveRange(1, _bodyParts.Count - 1);
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

