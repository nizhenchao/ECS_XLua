AppModulus = { }

function AppModulus:init()
    self.modulusMap = {}
end 

function AppModulus:register(name)
    if name then 
       
    end 
end 

create(AppModulus)



function Register(name)
   local class = nil 
   if _G[name] then 
      class = _G[name]
   else
   	  print("Register(name) 没有此类 name : "..name)
   end 
   if class then 
   	  if class.init then 
   	  	 class:init()
   	  end 
   	  if class.initEvent then 
   	  	 class:initEvent()
   	  end 
   end 
end  

function sendMsg(name)
    EventMgr:sendMsg(name,'cs call')
end