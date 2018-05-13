using Godot;
using System;
using System.Collections.Generic;

public class LoonyLips : Node2D
{
    Dictionary<List<string>, string> currentStory = new Dictionary<List<string>, string>();

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
		GD.Print("Hello from C#");  // print to Console
        SetRandomStory();
        // load_all_strings()
        (FindNode("StoryText") as RichTextLabel).Text = "Boom";
        // prompt_player(false)
    }

    private void SetRandomStory()
    {
        List<String> prompts = new List<String>();
        prompts.Add("a noun (thing)");
        prompts.Add("a verb");
        string story = "Once upon a time";
        currentStory.Add(prompts, story);
    }

//    public override void _Process(float delta)
//    {
//        
//    }
}
