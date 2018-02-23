LSkillComp = SimpleClass(LComponent)

function LSkillComp:__init(type,uid,args)
    self.skillDict = HashTable()  --技能列表
    self:parseSkills(args)

    self.castQueue = LQueue()
end 

function LSkillComp:isNeedUpdate()
	return not self.castQueue:isEmpty() 
end 

function LSkillComp:update()

end 

function LSkillComp:getArgs()
	return self.skillDict
end 

function LSkillComp:parseSkills(args)
    if args and #args>0 then 
       for i = 1,#args do        	   
       	   local skillConf = ConfigHelper:getConfigByKey('SkillConfig',args[i])
       	   if skillConf then 
       	   	  self.skillDict:add(skillConf.id,skillConf)
       	   end 
       end
    end
end 