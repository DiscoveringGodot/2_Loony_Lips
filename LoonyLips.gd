extends Node2D

var player_words = []   # the words the player chooses
var current_story
var strings = []  # every word displayed to user, in chosen language

func _ready():
	set_random_story()
	load_all_strings()
	$Blackboard/StoryText.text = strings['intro_text']
	prompt_player(false)


func set_random_story():
	var stories = get_dict_from_json('stories.json')
	randomize()
	current_story = stories.values()[randi() % stories.size()]


func load_all_strings():
	strings = get_dict_from_json('other_strings.json')


func get_dict_from_json(filename):
	var file = File.new()
	file.open(filename, File.READ)  # assumes file exists
	var text = file.get_as_text()
	var dict = {}
	dict = parse_json(text)
	return dict
	file.close()


func _on_TextureButton_pressed():
	if is_story_done():
		get_tree().reload_current_scene()
	else:
		var new_text = $Blackboard/TextBox.get_text()
		_on_TextBox_text_entered(new_text)


func _on_TextBox_text_entered(new_text):
	player_words.append(new_text)
	$Blackboard/TextBox.text = ''
	check_player_word_length()


func is_story_done():
	return player_words.size() == current_story.prompt.size()


func prompt_player(clear_first):
	if clear_first:
		$Blackboard/StoryText.text = ('')
	var next_input = current_story.prompt[player_words.size()]
	$Blackboard/StoryText.text += (strings['prompt'] % next_input)


func check_player_word_length():
	if is_story_done():
		tell_story()
	else:
		prompt_player(true)


func tell_story():
	$Blackboard/StoryText.text = current_story.story % player_words
	$Blackboard/TextureButton/ButtonLabel.text = strings['again']
	end_game()


func end_game():
	$Blackboard/TextBox.queue_free()
