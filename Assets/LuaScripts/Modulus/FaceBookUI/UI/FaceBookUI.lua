FaceBookUI = SimpleClass(BaseUI)

--声明成员变量
function FaceBookUI:__init_Self()
	print("<color=yellow>FaceBookUI:__init_Self()</color>")
    self.img2 = UIWidget.LUIWidget
    self.img3 = UIWidget.LUIWidget
    self.nameText = UIWidget.LText

	self.img1 = LuaExtend:getNode(self.obj,'img1')
	self.animObj = LuaExtend:getNode(self.obj,'animObj')

    LuaExtend:addClickHandler(self.img1,function()
        UIMgr:openUI(UIEnum.UpDownAnimUI,nil)
    end)

	LuaExtend:setActive(self.animObj,false)

end 

function FaceBookUI:onOpen()
	print("<color=yellow>FaceBookUI:onOpen()</color>")
	self.nameText:setText("FaceBookUI:onOpen()")
end 