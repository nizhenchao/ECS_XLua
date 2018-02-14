FaceBookUI = SimpleClass(BaseUI)

--声明成员变量
function FaceBookUI:__init_Self()
	print("<color=yellow>FaceBookUI:__init_Self()</color>")
    self.btn1 = UIWidget.LButton
    self.btn2 = UIWidget.LButton
    self.img3 = UIWidget.LImage
    self.nameText = UIWidget.LText

	self.img1 = UIWidget.LUIWidget--LuaExtend:getNode(self.obj,'img1')
	self.animObj = UIWidget.LUIWidget--LuaExtend:getNode(self.obj,'animObj')
end 

function FaceBookUI:initLayout()
    local listener = LuaExtend:addEventListener(self.img1:getObj())
    listener:setClickHandler(function() 
         UIMgr:openUI(UIEnum.UpDownAnimUI,nil)
         LuaExtend:doShake(1.5,0.02,0.3,0.3)
    end)

	LuaExtend:setActive(self.animObj:getObj(),false)
	
	self.btn1:setOnClick(function() 
		print("<color=red>self.btn1:setOnClick onclick open guild ui </color>") 
		 EventMgr:sendMsg(GuildCmd.On_Open_UI)
	end)
    
    local lis2 = LuaExtend:addEventListener(self.img3:getObj())
	lis2:setClickHandler(function() 
         self.img3:setImage("baoxiang")
    end)

end 

function FaceBookUI:onOpen()
	print("<color=yellow>FaceBookUI:onOpen()</color>")
	self.nameText:setText("FaceBookUI")
end 