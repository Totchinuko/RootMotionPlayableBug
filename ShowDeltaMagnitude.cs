using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class ShowDeltaMagnitude : MonoBehaviour
    {
		public float yAxis;
		public string name;
	
		[SerializeField]
		[Range(0,1)]
		private float someSlider = 0.5f;
		
        public float deltaPositionMagnitude;
        public float maxDeltaP = 0f;
		public float distance = 0f;
		public float minDeltaP = 10000f;
		
        private void OnAnimatorMove()
        {
            Vector3 move = GetComponent<Animator>().deltaPosition / Time.deltaTime;
            deltaPositionMagnitude = move.magnitude;
            maxDeltaP = (deltaPositionMagnitude > maxDeltaP ? deltaPositionMagnitude : maxDeltaP);
            minDeltaP = (deltaPositionMagnitude < minDeltaP ? deltaPositionMagnitude : minDeltaP);
			distance += deltaPositionMagnitude;
        }
		
		private void OnGUI()
		{
			GUI.color = Color.black;
			Rect dp = new Rect(5, 5 + yAxis, 350, 20);
			Rect mdp = new Rect(5, 25 + yAxis, 350, 20);
			Rect min = new Rect(5, 45 + yAxis, 350, 20);
			Rect dist = new Rect(5, 65 + yAxis, 350, 20);
			
			GUI.Label(dp, name+" RM magnitude = "+deltaPositionMagnitude.ToString());
			GUI.Label(mdp, name+" RM max Magnitude = "+maxDeltaP.ToString());
			GUI.Label(min, name+" RM min Magnitude = "+minDeltaP.ToString());
			GUI.Label(dist, name+" Distance traveled = "+distance.ToString());
		}
    }