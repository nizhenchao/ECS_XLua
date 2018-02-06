LuaExtend = { }

--gameobject操作相关
function LuaExtend:setActive(obj,isActive)
   CS.LuaExtend.setActive(obj,isActive)
end 

--UI相关
function LuaExtend:setUINode(obj,node)
   CS.LuaExtend.setUINode(obj,node)
end

function LuaExtend:setSprite(obj,name)
   CS.LuaExtend.setSprite(obj,name)
end

function LuaExtend:addClickHandler(obj,handler)
   return CS.LuaExtend.addClickHandler(obj,handler)
end

function LuaExtend:getNode(obj,path)
   return CS.LuaExtend.getNode(obj,path)
end

--DoTween相关
function LuaExtend:doUpDownScaleAnim(obj,title,onComplete)
    return CS.LuaExtend.doUpDownScaleAnim(obj,title,onComplete)
end 

function LuaExtend:killTweener(tw,isDoComplete)
    CS.LuaExtend.killTweener(tw,isDoComplete)
end 