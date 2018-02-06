AppModulus = { }

function AppModulus:init()
    self.contorlPool = {}
end 

function AppModulus:addControl(name,contorl)
    if self.contorlPool[name] ~=nil then 
       print("<color=red>注册control错误 有相同contorl</color>")
       return
    end 
    self.contorlPool[name] = contorl
end 

create(AppModulus)


--Control ClassName
--uiEnum
--openUI EventCmd
--closeUI EventCmd
function Register(name,uiEnum,openCmd,closeCmd)
   local creator = nil 
   if _G[name] then 
      creator = _G[name]
   else
   	  print("Register(name) 没有此类 name : "..name)
      return 
   end 
   local contorl = creator(uiEnum,openCmd,closeCmd)
   AppModulus:addControl(name,contorl)
   print("注册contorl : "..name)
end  

function sendMsg(name)
    EventMgr:sendMsg(name,'cs call')
end