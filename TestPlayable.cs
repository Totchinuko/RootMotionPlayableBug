using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class TestPlayable : MonoBehaviour
{
    public DirectorUpdateMode mode;
    public AnimationClip run;
	private PlayableGraph graph;
    private AnimationPlayableOutput playableOutput;
    

    public void Awake()
	{
		graph = PlayableGraph.Create();
        graph.SetTimeUpdateMode(mode);
		
		playableOutput = AnimationPlayableOutput.Create(graph, "EthanWithPlayable", GetComponent<Animator>());

		var runClip = AnimationClipPlayable.Create(graph, run);
		
		playableOutput.SetSourcePlayable(runClip);

		graph.Play();
	}

    private void FixedUpdate()
    {
        if(mode == DirectorUpdateMode.Manual)
            graph.Evaluate(Time.fixedDeltaTime);
    }
}
