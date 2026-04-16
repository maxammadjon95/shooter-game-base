using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Interactions
{
	public class Gun : MonoBehaviour
	{
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;
        private Transform cameraTransform;

        public void Init(Transform cameraTransform)
        {
            this.cameraTransform = cameraTransform;
        }

        public void Shoot()
        {
            RaycastHit hit;

            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 50f))
            {
                firePoint.LookAt(hit.point);
            }
            else
            {
                firePoint.LookAt(cameraTransform.position + cameraTransform.forward * 50f);
            }


            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}