using UnityEngine;

namespace TankAttack
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioData _audioData;
        
        public static AudioManager Instance { get; private set; }
        
        // 런타임에서 생성할 AudioSource
        private AudioSource _audioFireSfx;
        private AudioSource _audioEngineSfx;
        private AudioSource _audioBGM;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }

            Init();
        }

        private void Init()
        {
            
        }
    }
}
