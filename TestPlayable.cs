using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class TestPlayable : MonoBehaviour
{	
	public AnimationClip run;
	private PlayableGraph graph;

	public void Awake()
	{
		graph = PlayableGraph.Create();
		
		var playableOutput = AnimationPlayableOutput.Create(graph, "EthanWithPlayable", GetComponent<Animator>());

		var runClip = AnimationClipPlayable.Create(graph, run);
		
		playableOutput.SetSourcePlayable(runClip);

		graph.Play();
	}
}
