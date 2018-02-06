UpDownAnimUI = SimpleClass(BaseUI)

function UpDownAnimUI:__init_Self()
	print("<color=yellow>UpDownAnimUI:__init_Self()</color>")

	self.animObj = LuaExtend:getNode(self.obj,'animObj')
	LuaExtend:setActive(self.animObj,false)
end 

function UpDownAnimUI:onOpen()
	if self.animObj ~= nil then 
		LuaExtend:setActive(self.animObj,true)
		LuaExtend:doUpDownScaleAnim(self.animObj,'您的余额不足,请及时冲值',function() UIMgr:closeUI(UIEnum.UpDownAnimUI) end)
	end 
end 