LuaExtend = { }

----------------------------------------------------------------------------
------------------------------gameobject操作相关----------------------------
----------------------------------------------------------------------------
function LuaExtend:setActive(obj,isActive)
   CS.LuaExtend.setActive(obj,isActive)
end 

function LuaExtend:setObjPos(obj,x,y,z)
   CS.LuaExtend.setObjPos(obj,x,y,z)
end

function LuaExtend:setObjPosTable(obj,lst)
   CS.LuaExtend.setObjPos(obj,lst[1],lst[2],lst[3])
end

----------------------------------------------------------------------------
------------------------------UI相关----------------------------------------
----------------------------------------------------------------------------
--设置UI在Canvas的层
function LuaExtend:setUINode(obj,node)
   CS.LuaExtend.setUINode(obj,node)
end
--设置Image sprite
function LuaExtend:setSprite(obj,name)
   CS.LuaExtend.setSprite(obj,name)
end
--给UI添加一个eventListener
function LuaExtend:addEventListener(obj)
   return CS.LuaExtend.addEventListener(obj)
end
--根据UI节点路径查找
function LuaExtend:getNode(root,path)
   return CS.LuaExtend.getNode(root,path)
end
--递归查找UI下面的一个节点
function LuaExtend:getNodeByRecursion(root,nodeName)
   return CS.LuaExtend.getNodeByRecursion(root,nodeName)
end
--设置UI的material属性
function LuaExtend:setMaterialFloat(img,key,val)
   CS.LuaExtend.setMaterialFloat(img,key,val)
end

----------------------------------------------------------------------------
------------------------------DoTween相关-----------------------------------
----------------------------------------------------------------------------
function LuaExtend:doUpDownScaleAnim(obj,title,onComplete)
    return CS.LuaExtend.doUpDownScaleAnim(obj,title,onComplete)
end 

function LuaExtend:doLocalMoveTo(obj,dur,endVal,call,delay)
    delay = delay and delay or 0 
    CS.LuaExtend.doLocalMoveTo(obj,dur,endVal,call,delay)
end
--销毁tween
function LuaExtend:killTweener(tw,isDoComplete)
    CS.LuaExtend.killTweener(tw,isDoComplete)
end 
--旋转
function LuaExtend:lerpRotation(obj,dir)
   CS.LuaExtend.lerpRotation(obj,dir)
end 
--dofloat
function LuaExtend:doFloatTo(call,startVal,endVal,dur,finish)
   return CS.LuaExtend.doFloatTo(call,startVal,endVal,dur,finish)
end 

---------------------------------------------------------------------------
------------------------------对象池相关-----------------------------------
---------------------------------------------------------------------------
--销毁gameObject 对象池会处理
function LuaExtend:destroyObj(obj)
    CS.LuaExtend.destroyObj(obj)
end 
--加载gameObject
function LuaExtend:loadObj(url,callBack)
   CS.LuaExtend.loadObj(url,callBack)
end
--加载场景
function LuaExtend:loadScene(level,progress)
  CS.LuaExtend.loadScene(level,progress)
end

--摄像机相关
function LuaExtend:setCameraPlayer(player)
   CS.LuaExtend.setCameraPlayer(player)
end
function LuaExtend:doShake(time,att,hor,ver)
   CS.LuaExtend.doShake(time,att,hor,ver)
end

---------------------------------------------------------------------------
------------------------------数学相关-----------------------------------
---------------------------------------------------------------------------
function LuaExtend:getVectorAngle(v1,v2)
   return CS.LuaExtend.getVectorAngle(v1,v2)
end

function LuaExtend:getMillTimer()
    return CS.LuaExtend.getMillTimer()
end

function LuaExtend:getSecTimer()
    return CS.LuaExtend.getSecTimer()
end