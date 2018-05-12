using Godot;
using System;

public class LoonyLips : Node2D
{
    [Export]  // Similar to [SerializeField] in Unity
    string someParam = "Hello";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
		GD.Print("Hello from VS Code");
        StoryText storyText = FindNode("StoryText") as StoryText;
        storyText.Text = "Welcome to Loony Lips!\n\nWe're going to tell a story and have a lovely time!\n\nCan I have XXX please?";
        // TODO sort out whitespacing
        // TODO consider all text in separate file
    }

//    public override void _Process(float delta)
//    {
//        
//    }
}
