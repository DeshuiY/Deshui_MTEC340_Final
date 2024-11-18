using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorScript
{
    [RequireComponent(typeof(AudioSource))]
    public class Door : MonoBehaviour
    {
        [SerializeField] private bool open;
        [SerializeField] private float smooth = 1.0f;
        [SerializeField] private float DoorOpenAngle = -90.0f;
        [SerializeField] private float DoorCloseAngle = 0.0f;
        [SerializeField] private AudioSource asource;
        [SerializeField] private AudioClip openDoor, closeDoor;

        void Start()
        {
            if (asource == null)
                asource = GetComponent<AudioSource>();
        }

        void Update()
        {
            var target = Quaternion.Euler(0, open ? DoorOpenAngle : DoorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);
        }

        public void OpenDoor()
        {
            open = !open;
            asource.clip = open ? openDoor : closeDoor;
            asource.Play();
        }
    }
}