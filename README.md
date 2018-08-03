# Discovering Godot - The Game Engine You've Been Waiting For
## Section 2 - Loony Lips
This is GameDev.tv's guide to the free and open source Godot game engine.  Learn the free to use, free to modify, free to create engine with one of the most successful online game develeopment educational groups out there.

You're welcome to download, fork or do whatever else legal with all the files! The real value is in our huge, high-quality online tutorials that accompany this repo.

## In This Section
Create a fun word game based on Madlibs while you get to grips with GDScript and the foundations of scripting.   Our ref: LL_GDT

## How To Build / Compile
This is a Godot project. If you're familiar with source control, then "clone this repo". Otherwise download the contents and place them in an empty folder that's in a convenient place.  Open Godot, ``Import Project`` and navigate to the folder you just made.  select ``project.godot`` and you're good to go.

No compiling necessary!  This is Godot, after all.

This branch is the course branch, each commit corresponds to a lecture in the course. The current state is our latest progress.

## Lecture List
Here are the lectures of the course for this section...

### 1 Planning Loony Lips
#### In this video (objectives)…
1 Discuss the game we're making
2 1 Discuss the game we're making 2 Examine the features we'll need to create

#### After watching (learning outcomes)…
Decide if this course is for you!

### 2 Introducing Arrays
#### In this video (objectives)…
Put all of our plugin words into an array
Put wildcards into our story text Merge the new array into the story

#### After watching (learning outcomes)…
Put all of our plugin words into an array Put wildcards into our story text Merge the new array into the story

### 3 RichTextLabel - Showing Text to the Player
#### In this video (objectives)…
1 Import assets into Godot
2 Create a background texture
3 Use the ``RichTextLabel`` node to display text to the plaer

#### After watching (learning outcomes)…
Learn how to resize the player's viewport, import assets into Godot, create a background texture, use ``RichTextLabel`` nodes and control them from the script.

### 4 LineEdit - Text From The Player
#### In this video (objectives)…
1 Create a LineEdit Node
2 Create a TextureButton Node
3 Connect Signals
4 Move between functions

#### After watching (learning outcomes)…
Take the player's input and change the displayed text to match it.

### 5 Appending Arrays and "If" conditions
#### In this video (objectives)…
1 Append player input to an array
2 Use one array's size to find a position in another array
3 Prompt the player based on how many words they've already entered
4 Use an if/else condition to check if the player needs to be asked another prompt

#### After watching (learning outcomes)…
Prompt the player to enter the right kind of word and inster the player's inputs into the story

### 6 queue_free() and reload_current_scene()
#### In this video (objectives)…
1 remove a node from the scene tree with queue_free()
2 restart the game with reload_current_scene()
3 learn to use ``return`` to get information from a function to the one that called it

#### After watching (learning outcomes)…
Allow the player to restart the game once the story's done!

### 7 Dictionaries - Adding a Story Template
#### In this video (objectives)…
1 Create dictionaries
2 Nest Dictionaries
3 use ''randomize()'' and ''randi()'' to generate random integers

#### After watching (learning outcomes)…
Create a template system for Loony Lips and pick random stories from the template by unleashing the awesome power of dictionaries.

### 8 JSON and File
#### In this video (objectives)…

1 Learn how to write JSON files
2 How to open and parse JSON in GDScript

### 9 Using Git With Godot ###
#### In this video (objectives)… ####

1. What version control is
1. Why it’s important
1. What to track, and what not
1. A reminder about “Lecture Project Changes”

#### After watching (learning outcomes)…
At least create a simple backup of your project folder by taking a zip. Optionally setup Git.


### 10 Introducing Visual Studio Code ###

**In this video (objectives)…**

1. What is Visual Studio Code?
1. Why would you use it?
1. How do you install it
1. What extensions we’ll be using.

**After watching (learning outcomes)…**

Setup and use Visual Studio Code with the Godot extension as an external text editor.


### 11 Using Godot Mono For C-Sharp

**In this video (objectives)…**

1. How to install the “Mono” version of Godot
1. About the version of Mono on your system
1. Adding our first C# script.


**After watching (learning outcomes)…**

Get the Mono version of Godot working so you can write C# code.


### 12 Finding Nodes In C-Sharp

**In this video (objectives)…**

1. Use `FindNode()` in Godot
1. How to cast to the right type


**After watching (learning outcomes)…**

Find and use nodes in C#.


### 13 Wiring Signals In C-Sharp

**In this video (objectives)…**

1. Create a new signal to a C# script
1. See how to use correct parameters
1. Refactor our code.


**After watching (learning outcomes)…**

Wire Godot signals to a C# method of your choice.


### 14 Reading JSON In C# ###

**In this video (objectives)…**

1. Open and read files in C#
2. Use `JSON.Parse()` on the file text
3. Protect against parsing errors.


**After watching (learning outcomes)…**

Create a `JSONParseResult` object from a text file using C# in Godot Engine.
