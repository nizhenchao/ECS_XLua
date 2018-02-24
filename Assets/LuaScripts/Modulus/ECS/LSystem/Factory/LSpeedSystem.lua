LSpeedSystem = SimpleClass(LSystem)

function LSpeedSystem:__init_self()
    self.subscibe = LCompType.Speed
end 

function LSpeedSystem:__init()

end 

function LSpeedSystem:onUpdate(lst)
    for k,v in pairs(lst) do 
        local isNeed = v.speed > 0 
        if isNeed then 
           local entity = EntityMgr:getEntity(v:getUid())
           if entity then 
              local ccComp = entity:getComp(LCompType.CharacterController)    
              if ccComp and ccComp.cc then           
                  ccComp.cc:SimpleMove(entity.root.transform.forward*v.speed)
              end
           end
        end 
    end 
end 

function LSpeedSystem:disposeComp(comp)

end