UpDownAnimUI = SimpleClass(BaseUI)

function UpDownAnimUI:__init_Self()
	--print("<color=yellow>UpDownAnimUI:__init_Self()</color>")
	self.animObj = UIWidget.LUIWidget --LuaExtend:getNode(self.obj,'animObj')
end 

function UpDownAnimUI:initLayout()
    LuaExtend:setActive(self.animObj:getObj(),false)
end 

function UpDownAnimUI:onOpen()
	--print("<color=red>UpDownAnimUI:onOpen</color>")
	if self.animObj ~= nil then 
		LuaExtend:setActive(self.animObj:getObj(),true)
		local str = self.args and tostring(self.args) or "喵喵喵？喵喵喵？喵喵喵？喵喵喵？"
		LuaExtend:doUpDownScaleAnim(self.animObj:getObj(),str,function() UIMgr:closeUI(UIEnum.UpDownAnimUI) end)
	end 
end 

function UpDownAnimUI:onClose()
--print("<color=red>UpDownAnimUI:onClose</color>")
end 

function UpDownAnimUI:onDispose()
--print("<color=red>UpDownAnimUI:onDispose</color>")
end 