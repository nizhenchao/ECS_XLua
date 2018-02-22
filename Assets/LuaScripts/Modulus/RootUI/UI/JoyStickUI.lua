JoyStickUI = SimpleClass(BaseUI)

local radius = 80
--声明成员变量
function JoyStickUI:__init_Self()
	self.pointImg = UIWidget.LUIWidget
	self.orgPos = nil 
	self.worldPos = nil 
end 

function JoyStickUI:initLayout()
    local listener = LuaExtend:addEventListener(self.pointImg:getObj())
    listener:setBeginDragHandler(Bind(self.onBeginDrag,self))
    listener:setDragHandler(Bind(self.onDrag,self))
    listener:setEndDragHandler(Bind(self.onEndDrag,self))
    
    local orgPos = self.pointImg:getPosition()
    self.worldPos = self.pointImg:getWorldPosition()
    self.orgPos = Vector2(orgPos.x,orgPos.y)
end 

function JoyStickUI:onBeginDrag()
    EventMgr:sendMsg(JoyStickCmd.On_Begin_Drag)
end 

function JoyStickUI:onDrag(eventData)
    --计算偏移
    local pos = eventData.position
    pos.x = pos.x - self.worldPos.x 
    pos.y = pos.y - self.worldPos.y    
    --1 计算dir
    local dir = (pos - self.orgPos)
    --print(dir.normalized)
    EventMgr:sendMsg(JoyStickCmd.On_Drag,dir)
    --计算img位置
    dir = dir.magnitude > radius and dir.normalized*radius or dir 
    self.pointImg:setPosition(dir.x,dir.y,0)
end 

function JoyStickUI:onEndDrag()
    EventMgr:sendMsg(JoyStickCmd.On_End_Drag)
    LuaExtend:doLocalMoveTo(self.pointImg:getObj(),0.1,Vector3(0,0,0),nil,nil)
end 

function JoyStickUI:onOpen()

end 