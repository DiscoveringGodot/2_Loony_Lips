using Godot;
using System;
using System.Collections.Generic;
// using System.IO;
// using System.Text;

struct Story
{
    public List<String> prompts;
    public String story;
}

public class LoonyLips : Node2D
{
    // private instance variables for state
    Story currentStory;
    Dictionary<string, string> strings = new Dictionary<string, string>();
    List<String> playerWords = new List<string>();

    // cached references for readability
    RichTextLabel buttonLabel;
    RichTextLabel storyText;
    LineEdit textEntryBox;

    // messages, then public methods, then private methods...
    public override void _Ready()
    {
        CacheComponents();
        ShowIntro();
        SetRandomStory();
        PromptPlayer();
    }

    private void CacheComponents()
    {
        // for more refactorability use "if c extends DesiredClass" or Groups
        buttonLabel = FindNode("ButtonLabel") as RichTextLabel;
        storyText = FindNode("StoryText") as RichTextLabel;
        textEntryBox = FindNode("TextBox") as LineEdit;
    }

    public void OnButtonPressed()
    {
        if (IsStoryDone())  // Button is now play again
        {
            GetTree().ReloadCurrentScene();
        }
        else
        {
            var userInput = textEntryBox.GetText();
            OnTextEntry(userInput);
        }
    }

    public void OnTextEntry(string entry)  // Note no need to bind in Signals
    {
        playerWords.Add(entry);
        textEntryBox.SetText("");
        storyText.SetText("");
        if (IsStoryDone())
        {
            TellStory();
        }
        else
        {
            PromptPlayer();
        }
    }

    private void ShowIntro()
    {
        SetStringsFromFile("stories.json");
        storyText.Text = strings["intro_text"];
    }

    private void PromptPlayer()
    {
        string nextPrompt = currentStory.prompts[playerWords.Count];
        storyText.Text += String.Format(strings["prompt"], nextPrompt); 
    }

    private void TellStory()
    {
        storyText.Text = String.Format(currentStory.story, playerWords.ToArray());
        buttonLabel.SetText(strings["again"]);
        EndGame();
    }


    private bool IsStoryDone()
    {
        return playerWords.Count == currentStory.prompts.Count;
    }

    private void SetStringsFromFile(string localFileName)
    {
        var file = new File();
        file.Open(localFileName, 1);  // Mode 1 is read only
        string jsonString = file.GetAsText();
        file.Close();
        var parseResult = JSON.Parse(jsonString);

        if (parseResult.Error != 0)
        {
            GD.Print("JSON Parse Error");
        }
        else
        {
            GD.Print("Strings JSON OK");
            ReadStrings();
        }
    }

    private void ReadStrings()
    {
        strings["intro_text"] = "Welcome to Loony Lips!\n\nWe're going to tell a story and have a lovely time!\n\n";
        strings["prompt"] = "Can I have {0} please ?";
        strings["again"] = "Again!";
    }

    private void SetRandomStory()
    {
        // TODO actually get from JSON!
        currentStory.prompts = new List<string>(new string[]
        {
            "a person's name",
            "a thing",
            "a feeling",
            "another feeling",
            "some things"
        });
        currentStory.story = "Once upon a time {0} ate a {1} and felt very {2}. It was a {3} day for all good {4}.";
    }

    private void EndGame()
    {
        textEntryBox.QueueFree();  // Remove text box
    }
}
