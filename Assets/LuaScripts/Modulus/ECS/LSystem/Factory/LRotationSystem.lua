LRotationSystem = SimpleClass(LSystem)

function LRotationSystem:__init_self()
    self.subscibe = LCompType.Rotation
end 

function LRotationSystem:__init()

end 

function LRotationSystem:onUpdate(lst)    
    for k,v in pairs(lst) do 
        local isNeed = v:isNeedUpdate()
        if isNeed then 
           local entity = EntityMgr:getEntity(v:getUid())
           if entity then 
             LuaExtend:lerpRotation(entity.root,v.angle)
             --v.isChange = false 
           end
        end 
    end 
end 

function LRotationSystem:disposeComp(comp)

end