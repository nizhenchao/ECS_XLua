LCCComp = SimpleClass(LComponent)

function LCCComp:__init(type,uid,args)
    self.ccHeight = args[1] 
    self.ccRadius = args[2]
    self.cc = nil 
    self.isChange = true 
end 

function LCCComp:isNeedUpdate()
	return self.isChange and self.cc == nil 
end 

function LCCComp:setCC(cc)
   self.cc = cc 
end 

function LCCComp:getCC()
   return self.cc
end 