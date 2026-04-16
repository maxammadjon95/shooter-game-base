using Assets.Scripts.Interactions;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class GunHolder : MonoBehaviour
    {
        [SerializeField] private Gun _defaultGun;
        [SerializeField] private Gun _pistol;
        [SerializeField] private Transform _gunHoldingPoint;
        [SerializeField] private Transform _cameraTransform;

        private Gun _currentGun = null;
        private List<Gun> _instantiatedGuns = new List<Gun>();
        private int _currentGunID = 0;

        public void Shot()
        {
            if (_currentGun == null) return;
            _currentGun.Shoot();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                if (_currentGun == null)
                    CreateAGun(_defaultGun);
                else if(_instantiatedGuns.Count == 1)
                {
                    HideTheGun();
                    CreateAGun(_pistol);
                    _currentGunID = 1;
                }
                else
                {
                    SwitchGuns();
                }
        }

        private void CreateAGun(Gun gun)
        {
            var item = Instantiate(gun, _gunHoldingPoint.position, _gunHoldingPoint.rotation, _gunHoldingPoint);
            item.Init(_cameraTransform);
            _currentGun = item;
            _instantiatedGuns.Add(item);
        }

        private void HideTheGun()
        {
            _currentGun.gameObject.SetActive(false);
        }

        private void SwitchGuns()
        {
            HideTheGun();
            _currentGunID++;
            if (_currentGunID >= _instantiatedGuns.Count) _currentGunID = 0;
            _currentGun = _instantiatedGuns[_currentGunID];
            _currentGun.gameObject.SetActive(true);
        }
    }
}