LAnimSystem = SimpleClass(LSystem)

function LAnimSystem:__init_self()
    self.subscibe = LCompType.Animator
end 

function LAnimSystem:__init()

end 

function LAnimSystem:onUpdate(lst)    
    for k,v in pairs(lst) do 
        local isNeed = v:isNeedUpdate()        
        if isNeed then
             local entity = EntityMgr:getEntity(v:getUid())               
             if entity then 
                local anim = entity.root:GetComponentInChildren(Animator)
                if anim then 
                   v.anim = anim 
                end 
             end 
        end
        local isChnageAnim = v:isAnimChange()
        if isChnageAnim then 
             local entity = EntityMgr:getEntity(v:getUid())               
             if entity then 
                  local animComp = entity:getComp(LCompType.Animator)
                  if animComp and animComp.anim then 
                     animComp.anim:SetTrigger(animComp.triggerName)
                     animComp.animChaned = false 
                  end
             end   
        end 
    end 
end 

function LAnimSystem:disposeComp(comp)

end