LCCSystem = SimpleClass(LSystem)

function LCCSystem:__init_self()
    self.subscibe = LCompType.CharacterController
end 

function LCCSystem:__init()

end 

function LCCSystem:onUpdate(lst)
    for k,v in pairs(lst) do 
        local isNeed = v:isNeedUpdate()
        if isNeed then --创建模型
             local entity = EntityMgr:getEntity(v:getUid())               
             if entity then 
                local cc = entity.root:AddComponent(CharacterController)
                cc.height = v.ccHeight
                cc.radius = v.ccRaidus
                cc.center = Vector3(0,v.ccHeight/2,0)
                v:setCC(cc)
             end 
        end
    end 
end 

function LCCSystem:disposeComp(comp)

end