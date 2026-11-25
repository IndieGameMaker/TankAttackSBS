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
            // AudioSource 컴포넌트 생성
            _audioFireSfx   = this.gameObject.AddComponent<AudioSource>();
            _audioEngineSfx = this.gameObject.AddComponent<AudioSource>();
            _audioBGM       = this.gameObject.AddComponent<AudioSource>();
            
            // AudioSource의 Output 설정
            _audioFireSfx.outputAudioMixerGroup = _audioData.audioMixer.FindMatchingGroups(_audioData.fireSfxMG)[0];
            _audioEngineSfx.outputAudioMixerGroup = _audioData.audioMixer.FindMatchingGroups(_audioData.engineSfxMG)[0];
            _audioBGM.outputAudioMixerGroup = _audioData.audioMixer.FindMatchingGroups(_audioData.battleBgmMG)[0];
            
            // Loop 설정
            _audioFireSfx.loop      = false;
            _audioEngineSfx.loop    = true;
            _audioBGM.loop          = true;
            
            // 배경음악 재생
            StartBGM();
        }

        public void StartBGM()
        {
            if (_audioBGM.isPlaying) return;

            _audioBGM.clip = _audioData.battleBgm;
            _audioBGM.Play();
        }
    }
}
