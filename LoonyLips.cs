using Godot;
using System;

public class LoonyLips : Node2D
{
    // cached references
    RichTextLabel storyText;
    LineEdit textEntryBox;

    public override void _Ready()
    {
        CacheComponents();
        ShowIntro();
        // SetRandomStory();
        // PromptPlayer();
    }

    // Start of signals
    void OnTextEntry(String entry)  
    {
        GD.Print("Text entered: " + entry);
    }

    void OnButtonPressed()
    {
        GD.Print("Button pressed");
    }
    // End of signals

    void CacheComponents()
    {
        storyText = FindNode("StoryText") as RichTextLabel;
        textEntryBox = FindNode("TextBox") as LineEdit;
    }

    private void ShowIntro()
    {
        storyText.Text = "It worked!";
        textEntryBox.Text = "I wrote a line of text!";
    }
}
