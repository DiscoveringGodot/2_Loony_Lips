using Godot;
using System;
using System.Collections.Generic;

public class LoonyLips : Node2D
{
    public override void _Ready()
    {
        RichTextLabel storyText = FindNode("StoryText") as RichTextLabel;
        storyText.Text = "And so it begins";

        LineEdit textBox = FindNode("TextBox") as LineEdit;
        textBox.Text = "Enter your worst";
    }


//    public override void _Process(float delta)
//    {
//        
//    }
}
