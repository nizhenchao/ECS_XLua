FaceBookUI = SimpleClass(BaseUI)

--声明成员变量
function FaceBookUI:__init_Self()
	print("<color=yellow>FaceBookUI:__init_Self()</color>")
    self.btn1 = UIWidget.LButton
    self.img3 = UIWidget.LImage
    self.nameText = UIWidget.LText

	self.img1 = UIWidget.LUIWidget--LuaExtend:getNode(self.obj,'img1')
	self.animObj = UIWidget.LUIWidget--LuaExtend:getNode(self.obj,'animObj')
end 

function FaceBookUI:initLayout()
    LuaExtend:addClickHandler(self.img1:getObj(),function()
        UIMgr:openUI(UIEnum.UpDownAnimUI,nil)
    end)

	LuaExtend:setActive(self.animObj:getObj(),false)
	self.img3:setImage("baoxiang")
	self.btn1:setOnClick(function() print("<color=red>self.btn1:setOnClick onclick </color>") end)
end 

function FaceBookUI:onOpen()
	print("<color=yellow>FaceBookUI:onOpen()</color>")
	self.nameText:setText("FaceBookUI:onOpen()")
end 