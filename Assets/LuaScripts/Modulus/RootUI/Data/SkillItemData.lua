SkillItemData = SimpleClass()

function SkillItemData:__init(conf)
	self.conf = conf 
	self.castTime = -1
end 

function SkillItemData:setCastTime()--毫秒级
    self.castTime = LuaExtend:getMillTimer() 
end 

function SkillItemData:isInCd()
	return LuaExtend:getMillTimer() - self.castTime < self:getSkillCd()
end 

function SkillItemData:getLeftCd()
  local time = self:getSkillCd() - (LuaExtend:getMillTimer() - self.castTime)*0.001
  if time < 1 then 
  	return string.format("%0.1f",time)
  else
  	return math.ceil(time)
  end   
end 

function SkillItemData:getId()
	return self.conf and self.conf.id or '' 
end 

function SkillItemData:getAnimName()
	return self.conf and self.conf.animName or '' 
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