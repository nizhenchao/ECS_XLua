SkillUIItem = SimpleClass(BaseItem)

function SkillUIItem:__init()

end 

function SkillUIItem:__init_Self()
    self.skillIcon = UIWidget.LImage
    self.skillName = UIWidget.LText
    self.cdMask = UIWidget.LImage
    self.coolText = UIWidget.LText
end 

function SkillUIItem:initLayout()
	local listener = LuaExtend:addEventListener(self.obj)
	listener:setUseAnim(true)
    listener:setClickHandler(function()  	
    	if not self.isInCd then 
	    	local id = self.data:getId()
	    	EventMgr:sendMsg(BottomSkillCmd.On_Cast_Skill,id)
 	        --print("cast skill skillID "..id)
    	end 
    end)
end

function SkillUIItem:onOpen()
	--print("zzzzzfunction SkillUIItem:onOpen()")
end 

function SkillUIItem:onRefresh(data)
   if not data then 
   	  return 
   end 
   self.data = data 
   local icon = self.data:getIcon()
   self.skillIcon:setImage(icon)
   local name = self.data:getSkillName()
   self.skillName:setText(name)
   local isInCd = self.data:isInCd()
   self.isInCd = isInCd
   if isInCd then 
   	  self.cdMask:setActive(true)
   	  self.cdMask:setFillAmount(1)
   	  local cd = self.data:getSkillCd()
   	  self.coolText:setText(cd)
   	  LuaExtend:doFloatTo(function(val) self.cdMask:setFillAmount(val) self.coolText:setText(self.data:getLeftCd()) end,1,0,cd,function() 
   	  	self.cdMask:setActive(false) self.isInCd = false self.coolText:setText('') end)
   end 
end 