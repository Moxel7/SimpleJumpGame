using UnityEngine;

namespace World
{
    public class WallFollowPlayer : MonoBehaviour
    {

        public float playerY;
        public Transform playerTransform;
        private GameObject _player;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            playerTransform = _player.transform;
            playerY = playerTransform.position.y;
            //Eigene Höhe anhand der Spieler Höhe
            transform.position = new Vector3(transform.position.x, playerY, transform.position.z);
        }
    }
}
