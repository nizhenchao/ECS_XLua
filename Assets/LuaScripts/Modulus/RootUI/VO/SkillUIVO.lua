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

function SkillUIVO:updateSkillCd(id)	
	if not self.normalLst then 
		return 
	end 
	for i = 1,#self.normalLst do 
		local data = self.normalLst[i]
		if data:getId() == id then 
			data:setCastTime()
			return 
		end 
	end 
	for i = 1,#self.supLst do 
		local data = self.supLst[i]
		if data:getId() == id then 
			data:setCastTime()
			return 
		end 
	end 
end 