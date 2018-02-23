SkillItemData = SimpleClass()

function SkillItemData:__init(conf)
	self.conf = conf 
end 

function SkillItemData:getIcon()
   return self.conf and self.conf.icon or ''
end 

function SkillItemData:getSkillName()
    return self.conf and self.conf.name or ''
end 

function SkillItemData:getSkillCd()
    return self.conf and self.conf.cooldown or 0
end 

function SkillItemData:getType()
	return self.conf and self.conf.type or -1
end 