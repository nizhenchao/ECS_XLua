SkillUIVO = SimpleClass()

function SkillUIVO:__init(...)
	self.baseSkill = nil 
	self.normalLst = nil  
	self.supLst = nil
end 


function SkillUIVO:update(base,normalLst,supLst)
	self.baseSkill = base 
	self.normalLst = normalLst 
	self.supLst = supLst
end 

function SkillUIVO:getBaseSkill()
	return self.baseSkill
end 

function SkillUIVO:getNorSkill()
	return self.normalLst
end 

function SkillUIVO:getSupSkill()
	return self.supLst
end 