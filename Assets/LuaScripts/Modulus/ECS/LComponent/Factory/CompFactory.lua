CompFactory = { }

CompMap = { }
CompMap[LCompType.Model] = LModelComp
CompMap[LCompType.CharacterController] = LCCComp
CompMap[LCompType.Speed] = LSpeedComp
CompMap[LCompType.Rotation] = LRotationComp
CompMap[LCompType.Animator] = LAnimComp

function CompFactory:get(type,uid,args)
	local comp = nil 
    if CompMap[type] then 
    	local class = CompMap[type]
    	comp = class(type,uid,args)
    end 
    return comp 
end 