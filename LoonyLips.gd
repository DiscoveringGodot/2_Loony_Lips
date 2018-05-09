extends Node2D

var player_words = [] # the words the player chooses
var prompt = ["a name", "a thing", "a feeling", "another feeling", "some things"]
var story = "Once upon a time a %s ate a %s and felt very %s. It was a %s day for all good %s."

func _ready():
	$Blackboard/StoryText.text = ("Welcome to Loony Lips!\n\nWe're going to tell a story and have a lovely time!\nCan I have " + prompt[player_words.size()] + ", please?")
	$Blackboard/TextBox.text = ""

func _on_TextureButton_pressed():
	var new_text = $Blackboard/TextBox.get_text()
	_on_TextBox_text_entered(new_text)

func _on_TextBox_text_entered(new_text):
	player_words.append(new_text)
	$Blackboard/TextBox.text = ""
	check_player_word_length()

func prompt_player():
	$Blackboard/StoryText.text = ("Can I have " + prompt[player_words.size()] + ", please?")

func check_player_word_length():
	if player_words.size() == prompt.size():
		tell_story()
	else:
		prompt_player()

func tell_story():
	$Blackboard/StoryText.text = story % player_words