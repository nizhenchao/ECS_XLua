LAISystem = SimpleClass(LSystem)

function LAISystem:__init_self()
    self.subscibe = 10000--LCompType.AI
end 

function LAISystem:__init()

end 

function LAISystem:onUpdate(lst)
    for k,v in pairs(lst) do     
        local isNeed = v:isNeedUpdate()
        if isNeed then --创建模型
             local entity = EntityMgr:getEntity(v:getUid())               
             if entity then                 
                local pos = Vector3(-10,0,-10)
                print(pos)
                print("ai 思考出下一个巡逻点")
                entity:updateComp(LCompType.Position,pos)
                v:thinkFinish()
             end 
        end
    end 
end 

function LAISystem:disposeComp(comp)

end