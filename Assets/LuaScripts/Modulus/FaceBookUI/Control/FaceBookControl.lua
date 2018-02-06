FaceBookControl = SimpleClass(BaseControl)

function FaceBookControl:__init(...)

end 

function FaceBookControl:__init_self()

end 

function FaceBookControl:initEvent()
	--EventMgr:addListener(Define.On_Scene_Load_Begin,Bind(self.onSceneLoadBegin,self))
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('FaceBookControl',UIEnum.FaceBookUI,FaceBookCmd.On_Open_UI,FaceBookCmd.On_Close_UI)