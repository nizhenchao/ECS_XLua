function create(class)
   if class then 
   	  if class.init then 
         class:init()
   	  end 
   end
end 

require "Assets.LuaScripts.Modulus.LuaStart.__init"