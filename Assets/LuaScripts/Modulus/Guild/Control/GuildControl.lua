GuildControl = SimpleClass(BaseControl)

function GuildControl:__init(...)

end 

function GuildControl:__init_self()

end 

function GuildControl:initEvent()
	--EventMgr:addListener(Define.On_Scene_Load_Begin,Bind(self.onSceneLoadBegin,self))
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('GuildControl',UIEnum.GuildUI,GuildCmd.On_Open_UI,GuildCmd.On_Close_UI)