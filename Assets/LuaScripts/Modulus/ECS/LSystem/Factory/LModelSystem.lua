LModelSystem = SimpleClass(LSystem)

function LModelSystem:__init_self()
    self.subscibe = 1 
end 

function LModelSystem:__init()

end 

function LModelSystem:onUpdate(lst)
    for k,v in pairs(lst) do 
        local isNeed = v:isNeedUpdate()
        if isNeed then --创建模型
        	v:setStatus(LoadStatus.loading)
        	local path = v:getPath()        	
        	LuaExtend:loadObj(path,function(obj) 
               local entity = EntityMgr:getEntity(v:getUid())               
               if entity then --加载完毕实体未被销毁                                  	   
				   obj.transform:SetParent(entity.root.transform)
				   LuaExtend:setObjPosTable(obj,{0,0,0})
				   v:setModelObj(obj)
				   v:setStatus(LoadStatus.success)
			   else--加载完毕实体已经销毁
                   LuaExtend:destroyObj(obj)
               end 
        	end)
        end
    end 
end 

function LModelSystem:disposeComp(comp)
	if comp then 
       LuaExtend:destroyObj(comp:getModelObj())
    end
end