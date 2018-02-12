SceneControl = SimpleClass(BaseControl)

function SceneControl:__init(...)

end 

function SceneControl:__init_self()

end 

function SceneControl:initEvent()
	EventMgr:addListener(Define.On_Scene_Load_Begin,Bind(self.onSceneLoadBegin,self))
	EventMgr:addListener(Define.On_Scene_Load_Finish,Bind(self.onSceneLoadEnd,self))
end 

function SceneControl:onSceneLoadBegin()
    print("场景加载开始 CS call Lua")
    --TimeMgr:clear()
    UIMgr:onLoadScene()
    EntityMgr:onLoadScene()
end 

function SceneControl:onSceneLoadEnd()
    print("场景加载完毕 CS call Lua")
    EventMgr:sendMsg(BottomMidCmd.On_Open_UI)
    EventMgr:sendMsg(JoyStickCmd.On_Open_UI)
    --EventMgr:sendMsg(FaceBookCmd.On_Open_UI)

end 

Register('SceneControl')