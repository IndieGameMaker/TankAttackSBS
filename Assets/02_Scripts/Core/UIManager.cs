using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankAttack
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [Header("UI")] 
        public Image crossHair;
        public TextMeshProUGUI distanceText;

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
        }

        private IEnumerator Start()
        {
            SetDetectTarget(true);
            yield return new WaitForSeconds(3f);
            SetDetectTarget(false);
            SetTargetDistance(53.4f);
        }

        #region UI Methods
        public void SetDetectTarget(bool isDetect)
        {
            crossHair.color = isDetect ? Color.red : Color.white;
        }

        public void SetTargetDistance(float distance)
        {
            distanceText.text = $"{distance:000}m";
        }
        #endregion
    }
}
