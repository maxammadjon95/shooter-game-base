using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Interactions
{
	public class Gun : MonoBehaviour
	{
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private Transform cameraTransform;

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