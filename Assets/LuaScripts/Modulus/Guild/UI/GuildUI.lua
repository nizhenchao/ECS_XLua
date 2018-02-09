GuildUI = SimpleClass(BaseUI)

--声明成员变量
function GuildUI:__init_Self()
	print("<color=yellow>GuildUI:__init_Self()</color>")
	self.btn2 = UIWidget.LButton
	self.btn1 = UIWidget.LButton
end 

function GuildUI:initLayout()
	self.btn2:setOnClick(function() 		
		 EventMgr:sendMsg(GuildCmd.On_Close_UI)
	end)
	self.btn1:setOnClick(function() 		
		 EventMgr:sendMsg(FaceBookCmd.On_Open_UI)
	end)
end 

function GuildUI:onOpen()
	print("<color=yellow>GuildUI:onOpen()</color>")
end 