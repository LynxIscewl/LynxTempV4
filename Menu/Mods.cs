﻿using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using StupidTemplate.Classes;
using UnityEngine;

namespace StupidTemplate.Menu
{
    internal class Mods
    {
        
        private static GameObject leftplat;
        private static GameObject rightplat;
        private static GameObject SpawnPlat(Transform handTransform)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
            gameObject.transform.position = handTransform.position;
            gameObject.transform.rotation = handTransform.rotation;
            float num = (float)Time.frameCount / 180f % 1f;
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = new Color(0.85f, 0.60f, 0.65f);

            return gameObject;
        }


        public static void Platforms()
        {
            if (ControllerInputPoller.instance.leftGrab && leftplat == null)
            {
                leftplat = SpawnPlat(GorillaTagger.Instance.leftHandTransform);
            }

            if (ControllerInputPoller.instance.rightGrab && rightplat == null)
            {
                rightplat = SpawnPlat(GorillaTagger.Instance.rightHandTransform);
            }

            if (ControllerInputPoller.instance.leftGrabRelease && leftplat != null)
            {
                leftplat.Disable();
                leftplat = null;
            }

            if (ControllerInputPoller.instance.rightGrabRelease && rightplat != null)
            {
                rightplat.Disable();
                rightplat = null;
            }
        }

        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }
    }
}
