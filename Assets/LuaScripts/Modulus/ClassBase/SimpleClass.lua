--[[
 usage =
 基础类
    base = SimpleClass()
 继承类
    inheri = SimpleClass(base)

 function base:__init()
 end
]]--
--[[ 这个类是浅复制父类的方法，单向继承，
     使用这个类是因为luajit的检索深度过深会崩溃 ]]--

local function _visit_constructor(obj, t)
  if obj then
    t[#t+1] = obj
  end

  if obj._base then
    _visit_constructor(obj._base,t)
  else
    return
  end
end

--这里是实现面向对象，多继承相关
function SimpleClass(base)
   local c = {}    -- a new class instance
   local _baseList = nil
   if type(base) == 'table' then
      -- our new class is a shallow copy of the base class!
      for i,v in pairs(base) do
         c[i] = v
      end
      -- record base
      c._base = base
      -- get base list, 获取父类列表
      _baseList = {}
      _visit_constructor(base,_baseList)
      c._baseList = _baseList
   end
   -- the class will be the metatable for all its objects,
   -- and they will look up their methods in it.
   c.__index = c
   -- expose a constructor which can be called by <classname>(<args>)
   local mt = {}
   mt.__call = function(class_tbl, ...)
     local obj = {}
     setmetatable(obj,c)
     -- inheri constructor
     if _baseList then
        local _size = #_baseList --依次调用 父类 __init call
        for i=_size, 1 , -1 do
          _baseList[i].__init(obj,...)
        end
     end
     obj:__init(...) --调用自己的__init
     return obj
   end

   c.is_a = function(self, klass)
      local m = getmetatable(self)
      while m do
         if m == klass then return true end
         m = m._base
      end
      return false
   end
   setmetatable(c, mt)
   return c
end