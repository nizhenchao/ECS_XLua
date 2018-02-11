BottomMidContorl = SimpleClass(BaseControl)

function BottomMidContorl:__init(...)

end 

function BottomMidContorl:__init_self()

end 

function BottomMidContorl:initEvent()
	--EventMgr:addListener(Define.On_Scene_Load_Begin,Bind(self.onSceneLoadBegin,self))
end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('BottomMidContorl',UIEnum.BottomMidUI,BottomMidCmd.On_Open_UI,BottomMidCmd.On_Close_UI)