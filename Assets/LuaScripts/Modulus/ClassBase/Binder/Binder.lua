--Binder.lua
--内容：绑定参数
--addby penghu

--功能：解析出绑定参数数组
--参数：1、...	可变参数
--返回：无
--addby penghu
local function _concat(...)
      local r = {}
      for _, l in ipairs ({...}) do
            for _, v in ipairs (l) do
                table.insert (r, v)
            end
     end
      return r
end

local function _bindFuncOne(func,arg1)
      return function(...)
                      if func~=nil then
                        return func(arg1,...)
                      end
                  end
end

local function _bindFuncTwo(func,arg1,arg2)
      return function(...)
              if func~=nil then
                  return func(arg1,arg2,...)
              end
           end
end

local function _bindFuncThree(func,arg1,arg2,arg3)
      return function(...)
              if func~=nil then
                return func(arg1,arg2,arg3,...)
              end
           end
end

local function _bindFuncFour(func,arg1,arg2,arg3,arg4)
      return function(...)
              if func~=nil then
                return func(arg1,arg2,arg3,arg4,...)
              end
           end
end

--功能：创建绑定函数
--参数：1、func	执行函数
--		  2、...	可变参数
--返回：无
--addby penghu
function Bind(func,arg1,arg2,arg3,arg4)
  local t_func = nil
    --传入四个参数
  if (arg1 and arg2 and arg3 and arg4) then
    t_func = _bindFuncFour(func,arg1,arg2,arg3,arg4)
  --传入三个参数
  elseif (arg1 and arg2 and arg3) then
    t_func = _bindFuncThree(func,arg1,arg2,arg3)
  --传入两个参数
  elseif (arg1 and arg2) then
    t_func = _bindFuncTwo(func,arg1,arg2)
  --传入一个参数
  elseif arg1 then
    t_func = _bindFuncOne(func,arg1)
  end

  return t_func
end