LBillBoardSystem = SimpleClass(LSystem)

function LBillBoardSystem:__init_self()
    self.subscibe = LCompType.BillBoard
end 

function LBillBoardSystem:__init()

end 

function LBillBoardSystem:onUpdate(lst)
    for k,v in pairs(lst) do 
        local isNeed = v:isNeedUpdate()
        if isNeed then --创建模型
             local entity = EntityMgr:getEntity(v:getUid())               
             if entity then 
                local root = Utils:newObj("BillBoard")
                v.root = root 
                root.transform:SetParent(entity.root.transform)
                v.billBoard = root:AddComponent(BillBoardWidget)
                local comp = entity:getComp(LCompType.CharacterController)
                local h = comp and comp:getArgs() or 0
                LuaExtend:setObjPos(root,0,h,0)             
                
             end 
        end
        local needUpdateName = v:isNeedUpdateName()
        if needUpdateName then 
            v.billBoard:setName(v.name,0.5)
        end 
    end 
end 

function LBillBoardSystem:disposeComp(comp)

end