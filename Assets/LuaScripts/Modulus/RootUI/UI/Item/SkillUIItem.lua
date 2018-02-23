SkillUIItem = SimpleClass(BaseItem)

function SkillUIItem:__init()

end 

function SkillUIItem:__init_Self()
    self.skillIcon = UIWidget.LImage
    self.skillName = UIWidget.LText
    self.cdMask = UIWidget.LImage
    self.coolText = UIWidget.LText
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
end 