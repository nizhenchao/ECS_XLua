CompFactory = { }

CompMap = { }
CompMap[LCompType.Model] = LModelComp
CompMap[LCompType.CharacterController] = LCCComp

function CompFactory:get(type,uid,args)
	local comp = nil 
    if CompMap[type] then 
    	local class = CompMap[type]
    	comp = class(type,uid,args)
    end 
    return comp 
end 