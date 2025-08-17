extends Control
#vars:
@onready var resolucao_obj: OptionButton = $config_tabs/video/resolucao
@onready var name_player: LineEdit = $config_tabs/game/name_player
@onready var n_wins: Label = $config_tabs/game/n_wins
@onready var n_ponto: Label = $config_tabs/game/n_ponto
@onready var n_txt: Label = $config_tabs/audio/n_txt

@export var tile_scream : String

var resolucao
var is_fullscreaw 
var vaule 

#uppdate vars:
func _on_zera_status_button_up() -> void: game(true)
func _on_tela_cheia_toggled(toggled_on: bool) -> void: is_fullscreaw = toggled_on
func _on_resolucao_item_selected(index: int) -> void: resolucao = index#<-pega qual é a resolução 
func _on_audio_value_changed(Value: float) -> void: vaule = Value

func _on_rester_defaulte_pressed() -> void: 
	video_cofig(true)
	audio(true)

func _ready() -> void:
	game()
	video_cofig()
	audio()

func _on_voltar_pressed() -> void:
	get_tree().change_scene_to_file(tile_scream)

func _on_aplicar_pressed() -> void:
	video_cofig()
	audio()
	#controle

func video_cofig(is_defalt = false) -> void:
	if is_defalt == false:
		if is_fullscreaw:#<- tela cheia
			DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_FULLSCREEN)
		else:
			DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_WINDOWED)
		
		match resolucao:#<- resolução{swit case godot} 
			0:
				DisplayServer.window_set_size(Vector2i(1152,648))#<- parametro que altera a resolução
				resolucao_obj.select(0)#<- casso nessario autaliza o valor da opção para o user
			1:
				DisplayServer.window_set_size(Vector2i(1280,720))
				resolucao_obj.select(1)
			2:
				DisplayServer.window_set_size(Vector2i(1024,768))
				resolucao_obj.select(2)
			3:
				DisplayServer.window_set_size(Vector2i(1280, 960))
				resolucao_obj.select(3)
	
	else:#<- config defalt
			DisplayServer.window_set_size(Vector2i(1152,648))
			DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_WINDOWED)
			resolucao_obj.select(0)
	
	return

func game(zerar = false)-> void:
	name_player.set("text",Globals.info_user.get("name")) #<- altualiza o valor do nome do user
	
	if zerar == false: #<- ver se ele que zera os status
		n_wins.set("text", Globals.info_user.get("partidas_wins"))
		n_ponto.set("text",Globals.info_user.get("max_pontos"))
	else:
		Globals.info_user.set("partidas_wins", 000)
		Globals.info_user.set("max_pontos", 000)
		n_wins.set("text", Globals.info_user.get("partidas_wins"))
		n_ponto.set("text",Globals.info_user.get("max_pontos"))
	
	return

func _on_altera_nome_pressed() -> void:
	Globals.info_user.set("name", name_player.get("text"))
	game()

func audio(is_defalt = false) -> void:
	if is_defalt == false:
		pass
	else:
		pass
