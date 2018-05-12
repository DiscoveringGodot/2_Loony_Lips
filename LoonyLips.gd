extends Node2D

var player_words = [] # the words the player chooses
var current_story

func _ready():
	load_ramdom_story()
	$Blackboard/StoryText.text = ("Welcome to Loony Lips!\n\n")
	$Blackboard/StoryText.text += ("We're going to tell a story and have a lovely time!\n\n")
	prompt_player(false)

func load_ramdom_story():
	# TODO consdier checking for file existence
	var stories_file = File.new()
	stories_file.open("stories.json", File.READ)
	var text = stories_file.get_as_text()
	var stories = {}
	stories = parse_json(text)
	randomize()
	current_story = stories.values() [randi() % stories.size()]
	stories_file.close()

func _on_TextureButton_pressed():
	if is_story_done():
		get_tree().reload_current_scene()
	else:
		var new_text = $Blackboard/TextBox.get_text()
		_on_TextBox_text_entered(new_text)

func _on_TextBox_text_entered(new_text):
	player_words.append(new_text)
	$Blackboard/TextBox.text = ""
	check_player_word_length()

func is_story_done():
	return player_words.size() == current_story.prompt.size()

func prompt_player(clear_first):
	if clear_first:
		$Blackboard/StoryText.text = ("")
	$Blackboard/StoryText.text += ("Can I have " + current_story.prompt[player_words.size()] + ", please?")

func check_player_word_length():
	if is_story_done():
		tell_story()
	else:
		prompt_player(true)

func tell_story():
	$Blackboard/StoryText.text = current_story.story % player_words
	$Blackboard/TextureButton/ButtonLabel.text = "Again!"
	end_game()

func end_game():
	$Blackboard/TextBox.queue_free()