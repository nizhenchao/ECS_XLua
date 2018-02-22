BottomSkillControl = SimpleClass(BaseControl)

function BottomSkillControl:__init(...)

end 

function BottomSkillControl:__init_self()

end 

function BottomSkillControl:initEvent()
	--EventMgr:addListener(Define.On_Scene_Load_Begin,Bind(self.onSceneLoadBegin,self))
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('BottomSkillControl',UIEnum.BottomSkillUI,BottomSkillCmd.On_Open_UI,BottomSkillCmd.On_Close_UI)