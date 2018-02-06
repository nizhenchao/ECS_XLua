LuaExtend = { }

--gameobject操作相关
function LuaExtend:setActive(obj,isActive)
   CS.LuaExtend.setActive(obj,isActive)
end 

--UI相关
--设置UI在Canvas的层
function LuaExtend:setUINode(obj,node)
   CS.LuaExtend.setUINode(obj,node)
end
--设置Image sprite
function LuaExtend:setSprite(obj,name)
   CS.LuaExtend.setSprite(obj,name)
end
--给UI添加一个点击事件 需要扩展
function LuaExtend:addClickHandler(obj,handler)
   return CS.LuaExtend.addClickHandler(obj,handler)
end
--根据UI节点路径查找
function LuaExtend:getNode(root,path)
   return CS.LuaExtend.getNode(root,path)
end
--递归查找UI下面的一个节点
function LuaExtend:getNodeByRecursion(root,nodeName)
   return CS.LuaExtend.getNodeByRecursion(root,nodeName)
end

--DoTween相关
function LuaExtend:doUpDownScaleAnim(obj,title,onComplete)
    return CS.LuaExtend.doUpDownScaleAnim(obj,title,onComplete)
end 

function LuaExtend:killTweener(tw,isDoComplete)
    CS.LuaExtend.killTweener(tw,isDoComplete)
end 