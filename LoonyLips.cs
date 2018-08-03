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

        var result = GetJSONParseResult("stories.json");  // TODO remove
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

    private JSONParseResult GetJSONParseResult(string localFileName)
    {
        var file = new File();
        file.Open(localFileName, 1);  // Mode 1 is read only
        var text = file.GetAsText();
        file.Close();

        var parseResult = JSON.Parse(text);

        if (parseResult.Error != 0)
        {
            GD.Print(localFileName + " parse error");
            return null;
        }
        else
        {
            GD.Print(localFileName + " read OK");
            return parseResult;
        }
    }
}
