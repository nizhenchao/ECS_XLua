LModelComp = SimpleClass(LComponent)

function LModelComp:__init(type,uid,args)
    --根据skinId获取config
    self.modelConf = nil 
    self.modelObj = nil 
    self.loadStatus = LoadStatus.waiting

    self:setNewModel(args[1])
end 

function LModelComp:setNewModel(skinId)
   if skinId then 
   	  self.modelConf = ConfigHelper:getConfigByKey('ModelConfig',skinId)
   	  self.isChange = true 
   end 
end 

function LModelComp:isNeedUpdate()
	return self.isChange and self.loadStatus == LoadStatus.waiting
end 

function LModelComp:getPath()
	return self.modelConf and self.modelConf.path or ''
end 

function LModelComp:setModelObj(obj)
   self.modelObj = obj 
end 

function LModelComp:getModelObj()
   return self.modelObj
end 

function LModelComp:setStatus(status)
	self.loadStatus = status
end 