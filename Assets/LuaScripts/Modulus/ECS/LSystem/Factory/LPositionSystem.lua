LPositionSystem = SimpleClass(LSystem)

function LPositionSystem:__init_self()
    self.subscibe = LCompType.Position
end 

function LPositionSystem:__init()

end 

function LPositionSystem:onUpdate(lst)    
    for k,v in pairs(lst) do 
        local isNeed = v:isNeedUpdate()
        if isNeed then 
           local entity = EntityMgr:getEntity(v:getUid())
           if entity then 
              local dir = v.pos - entity.root.transform.position
              --print(v.pos)
              --print(dir.magnitude)
              local isArrive = dir.magnitude <= 1
              if not isArrive then
                entity:updateComp(LCompType.Animator,'walk')--动画
                local angle = LuaExtend:getAngle(dir)
                entity:updateComp(LCompType.Rotation,angle)--面向
                local comp = entity:getComp(LCompType.CharacterController)
                if comp and comp.cc then 
                   comp.cc:SimpleMove(dir.normalized)--cc
                end 
              else
                entity:updateComp(LCompType.Animator,'idle')
                local comp = entity:getComp(LCompType.CharacterController)
                if comp and comp.cc then 
                   comp.cc:SimpleMove(Vector3(0,0,0))
                end 
                v.isArrive = true 
              end
           end
        end 
    end 
end 

function LPositionSystem:disposeComp(comp)

end