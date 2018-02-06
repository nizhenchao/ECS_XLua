FaceBookUI = SimpleClass(BaseUI)

function FaceBookUI:__init()
	print("<color=yellow>FaceBookUI:__init()</color>")

	self.img1 = LuaExtend:getNode(self.obj,'img1')
	self.animObj = LuaExtend:getNode(self.obj,'animObj')

    LuaExtend:addClickHandler(self.img1,function()
        UIMgr:openUI(UIEnum.UpDownAnimUI,nil)
    end)

	LuaExtend:setActive(self.animObj,false)
end 

function FaceBookUI:onOpen()
	print("<color=yellow>FaceBookUI:onOpen()</color>")
end 